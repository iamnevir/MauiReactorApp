using MauiReactor;
using MauiReactor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetReactor.Pages
{
    internal class MainPageState
    {

    }

    internal class MainPage : Component<MainPageState>
    {
        async void OpenPlanetPage()
        {
            await Navigation.PushAsync<PlanetPage>();
        }
        public override VisualNode Render()
        {
            return new NavigationPage
            {
                 new ContentPage
                {
                       new Grid("*","*")
                       {
                           new Image("earth.svg")
                           .VStart()
                           .HCenter()
                           .TranslationX(-48)
                           .TranslationY(148)
                           .HeightRequest(96)
                           .WidthRequest(96)
                           ,
                           new Image("jupiter.svg")
                           .VCenter()
                           .HStart()
                           .TranslationX(-100)
                           .TranslationY(-64)
                           .HeightRequest(200)
                           .WidthRequest(200),
                           new Image("saturn.png")
                           .VCenter()
                           .HCenter()
                           .TranslationX(32)
                           .TranslationY(76)
                           .HeightRequest(300)
                           .WidthRequest(300),
                           new Image("mars.png")
                           .VStart()
                           .HStart()
                           .TranslationX(-100)
                           .TranslationY(96)
                           .HeightRequest(140)
                           .WidthRequest(140),
                           new Image("mercury.svg")
                           .VStart()
                           .HCenter()
                           .TranslationX(18)
                           .TranslationY(72)
                           .HeightRequest(66)
                           .WidthRequest(66),
                           new Image("venus.svg")
                           .VStart()
                           .HCenter()
                           .TranslationX(84)
                           .TranslationY(208)
                           .HeightRequest(76)
                           .WidthRequest(76),
                           new Image("uranus.svg")
                           .VCenter()
                           .HEnd()
                           .TranslationX(100)
                           .TranslationY(-72)
                           .HeightRequest(200)
                           .WidthRequest(200),
                           new Image("neptune.svg")
                           .VStart()
                           .HEnd()
                           .TranslationX(100)
                           .TranslationY(-72)
                           .HeightRequest(200)
                           .WidthRequest(200),
                           new Border
                           {
                               new VStack
                               {
                                   new Label("Hello!")
                                   .HCenter()
                                   .HorizontalTextAlignment(TextAlignment.Center)
                                   .FontAttributes(MauiControls.FontAttributes.Bold)
                                   .FontSize(32)
                                   .TextColor(Theme.DarkText),
                                   new Label("Want to know and explain all things about the planets in the Milky Way galaxy?")
                                   .HCenter()
                                   .HorizontalTextAlignment(TextAlignment.Center)
                                   .FontSize(16)
                                   .LineHeight(1.15)
                                   .LineBreakMode(LineBreakMode.WordWrap)
                                   .TextColor(Theme.DarkText),
                                   new Button("Explore Now")
                                   .HCenter()
                                   .FontSize(22)
                                   .TextColor(Colors.White)
                                   .FontFamily("MediumFont")
                                   .CornerRadius(26)
                                   .BackgroundColor(Color.FromArgb("#eb5757"))
                                   .Margin(0,12,0,6)
                                   .HeightRequest(52)
                                   .Padding(64,0)
                                   .OnClicked(OpenPlanetPage)
                                   ,

                               }.Spacing(14)
                           }.Padding(24,32)
                           .BackgroundColor(Color.FromArgb("#F1EFF0"))
                           .Stroke(Colors.Transparent)
                           .HFill()
                           .VEnd()
                           .StrokeShape(new RoundRectangle().CornerRadius(24))
                           .Margin(20)
                       }
                }.BackgroundColor(Theme.Bg)
            }.Set(MauiControls.NavigationPage.HasNavigationBarProperty,false)
            
            ;
        }
    }
}