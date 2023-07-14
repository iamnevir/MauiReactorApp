using MauiReactor;
using MauiReactor.Shapes;
using MauiSlanted.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MauiSlanted.Pages;

class MainPageState
{
    public bool Props { get; set; }
    public bool IsScroll { get; set; } = true;
}

class MainPage : Component<MainPageState>
{
    double _cl1;
    double _cl2;
    double _cl3;
    double _cl4;

    protected override  void OnMounted()
    {
        base.OnMounted();
        
    }

    protected override void OnPropsChanged()
    {
        _cl1 = State.Props == true ? 250 : -250;
        _cl2 = State.Props == true ? -200 : 200;
        _cl3 = State.Props == true ? 250 : -250;
        _cl4 = State.Props == true ? -200 : 200;
        base.OnPropsChanged();
    }

    public override VisualNode Render()
    {

        return new ContentPage
        {
            new Grid("538,Auto,*,76","*")
            {
                new Grid("130,10,130,10,130,10,130","*")
                {
                    new CollectionView()
                    .ItemsSource(ImageNFT.Collection1,RenderItem)
                    .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(10))

                    .TranslationX(_cl1)
                    .WithAnimation(duration:5000)
                    .GridRow(0),
                    new CollectionView()
                    .ItemsSource(ImageNFT.Collection2,RenderItem)
                    .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(10))

                     .TranslationX(_cl2)
                     .WithAnimation(duration:5000)
                    .GridRow(2),
                    new CollectionView()
                    .ItemsSource(ImageNFT.Collection3,RenderItem)
                    .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(10))

                     .TranslationX(_cl3)
                     .WithAnimation(duration:5000)
                    .GridRow(4),
                    new CollectionView()
                    .ItemsSource(ImageNFT.Collection4,RenderItem)
                    .ItemsLayout(new HorizontalLinearItemsLayout().ItemSpacing(10))

                     .TranslationX(_cl4)
                     .WithAnimation(duration:5000)
                    .GridRow(6)
                }.Rotation(-10)
                .GridRow(0)
                .WidthRequest(2000),
                new BoxView().HFill().VEnd()
                .HeightRequest(90)
                .Background(new MauiControls.LinearGradientBrush(
                    new MauiControls.GradientStopCollection
                    {
                         new MauiControls.GradientStop(Color.FromArgb("#FFFFFF"),0.0f),
                         new MauiControls.GradientStop(Color.FromArgb("#00FFFFFF"),1.0f),
                    },new Point(0,1),new Point(0,0)))
                .GridRow(0),
                 new BoxView().HFill().VStart()
                .HeightRequest(90)
                .Background(new MauiControls.LinearGradientBrush(
                    new MauiControls.GradientStopCollection
                    {
                         new MauiControls.GradientStop(Color.FromArgb("#FFFFFF"),0.0f),
                         new MauiControls.GradientStop(Color.FromArgb("#00FFFFFF"),1.0f),
                    },new Point(0,0),new Point(0,1)))
                .GridRow(0)
                ,
                 new BoxView().GridRow(1)
                 .HFill().VFill()
                 .GridRowSpan(3)
                 .BackgroundColor(Colors.White)
                ,

                new Label("Discover NFT Collections")
                .FontSize(28)
                .FontAttributes(MauiControls.FontAttributes.Bold)
                .TextColor(Color.FromArgb("#151515"))
                .Margin(48,12,48,0)
                .GridRow(1)
                .HCenter()
                .HorizontalTextAlignment(TextAlignment.Center)
                .LineHeight(1.2)
                ,
                new Label("Explore top collections of NFT and buy and sell your NFTs as well")
                .FontSize(18)
                .Margin(32,12,32,0)
                .HorizontalTextAlignment(TextAlignment.Center)
                .HCenter()
                .VStart()
                .LineHeight(1.2)
                .TextColor(Color.FromArgb("#888888"))
                .GridRow(2)
                ,
                new Button("Start Exploring")
                .BackgroundColor(Color.FromArgb("#151515"))
                .TextColor (Colors.White)
                .FontAttributes (MauiControls.FontAttributes.Bold)
                .HorizontalOptions(MauiControls.LayoutOptions.Fill)
                .VerticalOptions(MauiControls.LayoutOptions.Fill)
                .FontSize(18)
                .Margin(32,0,32,24)
                .BorderWidth(0)
                .OnClicked(Click)
                .CornerRadius(26)
                .GridRow(3)
            }
        };
    }
    private void Click()
    {
        OnPropsChanged();
        SetState(s => s.Props = !s.Props);
        _cl1 = State.Props == true ? -250 : 250;
        _cl2 = State.Props == true ? 200 : -200;
        _cl3 = State.Props == true ? -250 : 250;
        _cl4 = State.Props == true ? 200 : -200;
    }

    private VisualNode RenderItem(ImageNFT nFT)
    {
        return new Border
        {
             new Image(nFT.Src)
            .Aspect(Aspect.AspectFill)
            .HFill()
            .VFill()
            .WidthRequest(130)
            .HeightRequest(130)
        }.StrokeShape(new RoundRectangle().CornerRadius(16)).WidthRequest(130)
            .HeightRequest(130)
           ;
    }
}