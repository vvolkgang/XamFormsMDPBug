#Xamarin.Forms MasterDetailPage navigation bar bug demonstration

This repository is a self contained app to demonstrate two possible bugs related to the navigation bar (in Android at least) when using `MasterDetailPage` (MDP).

This repo README.md will be updated with possible solutions when they're found.

## Solutions

1. Following [FredrikNilsson](http://forums.xamarin.com/discussion/comment/118015/#Comment_118015) comment, to change the back button icon you need to set the Icon in the `MasterDetailPage.Master` page, instead of `MasterDetailPage`.
```xml
    <?xml version="1.0" encoding="utf-8" ?>
    <MasterDetailPage xmlns="http://xamarin.com/schemas/2014/forms"
                 xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                 x:Class="MDPBug.MasterPage">
      <MasterDetailPage.Master>
        <ContentPage Title="Menu" Icon="slideout.png">
            <StackLayout>
                <Button Text="MenuItem1"/>
                <Button Text="MenuItem1"/>
            </StackLayout>
        </ContentPage>
      </MasterDetailPage.Master>
    </MasterDetailPage>
```

# Bug report

**Xamarin.Forms version:** 1.4.2.6355

- MDP button in the navigation is always a back button
![Main Page](images/backbutton_bug.png)
- `Navigation.PageSetHasNavigationBar(this,false)` is only respected in pages you navigate to, but not in the first one
    + A workarround to this is to create the `NavigationPage` with an empty page and only afterwards navigate to the real one.
```csharp
    _navPage = new NavigationPage(new Page());
    _navPage.PushAsync(new MainPage());  
```

# Expected behaviour

The MDP button should be an hamburguer menu, similar to the [Hanselman App](https://github.com/jamesmontemagno/Hanselman.Forms)

# Demonstration 

When you run the app you can confirm the first bug, 10 seconds later the app will navigate to another page, where you can confirm the second problem (ie, confirm that it only works when you navigate to and doesn't in the first page).

# Notes

- The `NavigationPage` static set methods were abused through the app to demonstrate none of the alternatives work.
- In `SecondPage.xaml.cs`,  using `NavigationPage.SetHasBackButton(this, false);` actually disables the navigation back button, enabling the user to use the MDP menu from the button. Nonetheless, the button icon is still the same.

