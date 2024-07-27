Simple-UI-Manager

A simple UI manager which just gets the job done. I always found building UI for atleast the prototypes to be quite complicated for no reason, so I had this manager built
for testing and implementing my UI. I thought this could help save time for the people who is learning unity for the first time.

Things you can do with this
* Manage all the UI on your canvas just through one script
* Update any text on your UI with easy by just invoking an action and passing the name of the text
* Quickly toggle any image/panels
* Display a prompt for X seconds

Do note that I have little to no idea how expensive or costly it is in terms of memory usage, but if you are just getting started and you want a clean simple way to build
your UI then sure you can get this up and running in no time

  
How to?
* Create an empty Gameobject
* Add the UIGlobalManager on it
* Add any UI element you want to it by clicking on the (+) on it
* Name those elements accordingly

* Now, you can go to any script you want to call it from and just invoke the appropriate actions, 
- UIGlobalManager.ToggleMenu - Action to toggle a menu on/off
- UIGlobalManager.UpdateText - Action to update a text layer with a given value
- UIGlobalManager.DisplayPrompt - Action to display a prompt for x seconds
- UIGlobalManager.ListenerToButton - Action to add a listener to a button
