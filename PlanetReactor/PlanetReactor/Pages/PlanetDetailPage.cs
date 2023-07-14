using MauiReactor;
using MauiReactor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetReactor.Pages;

class PlanetDetailPageState
{
}
class PlanetDetailPageProps
{
    public Planet PlanetDetail { get; set; }
}
class PlanetDetailPage: Component<PlanetDetailPageState, PlanetDetailPageProps>
{
    protected override void OnMounted()
    {
        base.OnMounted();
    }
    public override VisualNode Render()
    {
        return new ContentPage
        {
               new Grid("75,*","Auto,*")
               {
                   new ImageButton("imgback")
                   .GridRow(0)
                   .GridColumn(0)
                   .HStart()
                   .VStart()
                   .HeightRequest(24)
                   .WidthRequest(24)
                   .Margin(15,40,0,0)
                   .OnClicked(GoBack),
                   new ImageButton("imgmenu")
                   .GridRow(0)
                   .GridColumn(1)
                   .HEnd()
                   .VStart()
                   .HeightRequest(24)
                   .WidthRequest(24)
                   .Margin(0,40,15,0),
                   new ScrollView
                   {
                       new VStack
                       {
                           new Image(Props.PlanetDetail.HeroImage)
                           .Aspect(Aspect.AspectFit)
                           .HFill()
                           .HeightRequest (240)
                           .Margin(24,0),
                           new Label(Props.PlanetDetail.Name)
                           .FontSize(48)
                           .FontAttributes(Microsoft.Maui.Controls.FontAttributes.Bold)
                           .TextColor(Theme.LightText)
                           .Margin(0,-24,0,0)
                           ,
                           new Label(Props.PlanetDetail.Subtitle)
                           .FontSize(22)
                           .TextColor(Theme.LightText)
                           .Margin(0,0,0,0),
                           new Rectangle().HFill()
                           .HeightRequest(2)
                           .Stroke(Colors.Transparent)
                           .Fill(Theme.LightBorder),
                           new Label(Props.PlanetDetail.Description)
                           .LineBreakMode(LineBreakMode.WordWrap)
                           .LineHeight(1.5)
                            .FontSize(16)
                           .TextColor(Theme.LightText)
                           ,
                           new Rectangle().HFill()
                           .HeightRequest(2)
                           .Stroke(Colors.Transparent)
                           .Fill(Theme.LightBorder),
                           new Label("Gallery")
                           .FontSize(22)
                           .TextColor(Theme.LightText)
                           ,
                           new CollectionView()
                           .ItemsSource(Props.PlanetDetail.Images,RenderItem)
                           .HeightRequest(160)
                           .Margin(0,-6,0,50)
                           .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(16))
                       }.Spacing(18)
                   }.GridRow(1)
                   .GridColumnSpan(2)
                   .HorizontalScrollBarVisibility(ScrollBarVisibility.Never)
                   .VerticalScrollBarVisibility(ScrollBarVisibility.Never)
                   .GridColumn(0)
                   .Margin(15,0,15,0)
               }
        }.BackgroundColor(Theme.Bg)
        .Set(MauiControls.NavigationPage.HasNavigationBarProperty,false);
    }

    private VisualNode RenderItem(string arg)
    {
        return new Image(arg)
            .Aspect(Aspect.AspectFill)
            .HFill()
            .VFill()
            .WidthRequest(160)
            .Clip(new RoundRectangleGeometry().CornerRadius(16).Rect( new Rect(0,0,160,160)))
        ;
    }
    private async void GoBack()
    {
        await Navigation.PopAsync();
    }
}
