using MauiReactor;
using MauiReactor.Shapes;
using PlanetReactor.Resources.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetReactor.Pages;

class PlanetPageState
{
    public List<Planet> PlanetList { get;} = PlanetsService.GetAllPlanets();
    public Planet PlanetSelected { get; set; }
}
class PlanetPage:Component<PlanetPageState>
{
    protected override void OnPropsChanged()
    {
        base.OnPropsChanged();
    }
    public override VisualNode Render()
    {
        
        return new ContentPage
        {
                new Grid("Auto,*","*,Auto")
                {
                    new VStack
                    {
                        new Label("Let's Explore")
                        .FontSize(32)
                        .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                        .TextColor(Colors.White),
                        new Label("The milky way galaxy")
                        .FontSize(14)
                        .TextColor(Theme.LightText),
                    }
                    .GridRow(0)
                    .GridColumn(0)
                    .VCenter()
                    .Spacing(4)
                    ,
                    new Border
                    {
                        new Image("phoenix.jpg")
                        .VCenter()
                        .HCenter()
                        .HeightRequest(50)
                        .WidthRequest(50)
                        .Clip(new EllipseGeometry()
                                    .Center(new Point(25,25))
                                    .RadiusX(25)
                                    .RadiusY(25))
                    }.StrokeShape(new RoundRectangle().CornerRadius(28))
                    .GridRow(0)
                    .GridColumn(1)
                    .StrokeThickness(6)
                    .HeightRequest(56)
                    .WidthRequest (56)
                    .VCenter()
                    .HEnd()
                    .Stroke(Colors.White),
                    new ScrollView
                    {
                        new VStack
                        {
                            new Border
                            {
                                new Grid("*","Auto,*")
                                {
                                    new Image("imgsearch")
                                    .GridColumn(0)
                                    .VCenter()
                                    .WidthRequest(18)
                                    .HeightRequest (18)
                                    .Margin(10,0,0,0)
                                    ,
                                    new Label("Search for your favorite planet")
                                    .GridColumn(1)
                                    .VCenter()
                                    .VerticalTextAlignment(TextAlignment.Center)  
                                    .FontSize(14)
                                    .TextColor(Color.FromArgb("#CCCCCC"))
                                }.HFill()
                                .VCenter()
                                .ColumnSpacing(16)

                            }.BackgroundColor(Color.FromArgb("#33CCCCCC"))
                            .HFill()
                            .Stroke(Colors.Transparent)
                            .StrokeShape(new RoundRectangle().CornerRadius(6))
                            .HeightRequest(48)
                            .Margin(0,0,24,0),
                            new HStack
                            {
                                   new Label("Most Popular")
                                    .FontSize(20)
                                    .TextColor(Theme.LightText),
                                   new Label("→")
                                       .FontSize(35)
                                    .TextColor(Theme.LightText)
                                    .Margin(0,-21,0,0)
                            }.Margin(0,12,0,0).Spacing(10),
                            new CollectionView()
                            .HeightRequest(280)
                            .SelectionMode(Microsoft.Maui.Controls.SelectionMode.Single)
                            .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(16))
                            .ItemsSource(State.PlanetList,RenderPlanetItem)
                            .Margin(0,10,0,0)
                            ,
                            new HStack
                            {
                                   new Label("You may also like")
                                    .FontSize(20)
                                    .TextColor(Theme.LightText),
                                   new Label("→")
                                       .FontSize(35)
                                    .TextColor(Theme.LightText)
                                    .Margin(0,-17,0,0)
                            }.Margin(0,12,0,0).Spacing(10),
                            new CollectionView()
                            .HeightRequest(160)
                            .SelectionMode(Microsoft.Maui.Controls.SelectionMode.Single)
                            .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(16))
                            .ItemsSource(State.PlanetList,RenderPlanetItem1)
                            .Margin(0,10,0,0)
                        }
                    }.GridRow(1)
                    .GridColumn(0)
                    .GridColumnSpan(2)
                    .HorizontalScrollBarVisibility(ScrollBarVisibility.Never)
                    .VerticalScrollBarVisibility(ScrollBarVisibility.Never)
                    .Margin(0,32,-24,0),
                    new Border
                    {
                        new Grid("Auto,Auto","*,*,*")
                        {
                            new Image("imgexplore")
                            .HeightRequest(30)
                            .WidthRequest(30)
                            .GridColumn(0)
                            .GridRow(0)
                            .HCenter(),
                            new Label("Explore")
                            .GridRow(1)
                            .FontSize(14)
                            .TextColor(Color.FromArgb("#CCCCCC"))
                            .GridColumn(0)
                            .HCenter(),
                            new Image("imgfavorite")
                            .HeightRequest(30)
                            .WidthRequest(30)
                            .GridColumn(1)
                            .GridRow(0)
                            .HCenter(),
                            new Label("Favorite")
                            .GridRow(1)
                            .FontSize(14)
                            .TextColor(Color.FromArgb("#CCCCCC"))
                            .GridColumn(1)
                            .HCenter(),
                            new Image("imgprofile")
                            .HeightRequest(30)
                            .WidthRequest(30)
                            .GridColumn(2)
                            .GridRow(0)
                            .HCenter(),
                            new Label("Profile")
                            .GridRow(1)
                            .FontSize(14)
                            .TextColor(Color.FromArgb("#CCCCCC"))
                            .GridColumn(2)
                            .HCenter(),

                        }.HFill()
                        .VCenter()
                        .RowSpacing(6)
                    }.Padding(16,0)
                    .BackgroundColor(Color.FromArgb("#393965"))
                    .HFill()
                    .VEnd()
                    .Margin(0,0,0,40)
                    .HeightRequest(90)
                    .GridRow(1)
                    .GridColumn(0)
                    .GridColumnSpan(2)
                    .StrokeShape(new RoundRectangle().CornerRadius(45))
                }.BackgroundColor(Theme.Bg)
                .Padding(24,52,24,0)
        }.Set(MauiControls.NavigationPage.HasNavigationBarProperty,false);
    }

    private VisualNode RenderPlanetItem1(Planet planet)
    {
        return new Border
        {
            new Grid("*,Auto","*")
            {
                new Image(planet.HeroImage)
                .GridRow(0)
                .Rotation(-30)
                .Aspect(Aspect.AspectFit)
                .VFill()
                .HFill(),

                new Label(planet.Name)
                .GridRow(1)
                .FontSize(20)
                .TextColor(Theme.LightText),
            }.RowSpacing(4)
        }.VFill()
         .WidthRequest(140)
         .Padding(20)
         .StrokeShape(new RoundRectangle().CornerRadius(24))
         .Background(planet.Background)
         .OnTapped(()=> {
             SetState(s => s.PlanetSelected = planet);
             OpenDetailPlanetPage();
             });
    }
    private async void OpenDetailPlanetPage()
    {
        await Navigation.PushAsync<PlanetDetailPage, PlanetDetailPageProps>(_ =>
        {
            _.PlanetDetail= State.PlanetSelected;
        });
    }

    private VisualNode RenderPlanetItem(Planet planet)
    {
        return new Border
        {
            new Grid("*,Auto,Auto","*")
            {
                new Image(planet.HeroImage)
                .GridRow(0)
                .Rotation(-30)
                .Aspect(Aspect.AspectFit)
                .VFill()
                .HFill(),
                
                new Label(planet.Name)
                .GridRow(1)
                .FontSize(20)
                .TextColor(Theme.LightText),
                new Label(planet.Subtitle)
                .GridRow(2)
                .FontSize(14)
                .TextColor(Theme.LightText),
            }.RowSpacing(4)
        }.VFill()
        .WidthRequest(220)
        .Padding(20)
        .StrokeShape(new RoundRectangle().CornerRadius(24))
        .Background(planet.Background)
        .OnTapped(() => {
            SetState(s => s.PlanetSelected = planet);
            OpenDetailPlanetPage();
        });
    }
}
