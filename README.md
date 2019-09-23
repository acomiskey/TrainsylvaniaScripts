# TrainsylvaniaScripts
C# files from the creation of Trainsylvania: A Cyber-Noir at Gator Game Jam 2019

These files are written to work in the Unity game engine and will not create any effect on their own.

CharacterEyesight.cs handles camera movement in response to mouse movement. It is intended to be applied to the main camera object.

CharacterMovement.cs handles player character movement in response to WASD input and the direction the camera is pointed. It is intended to be applied to an invisible player 3D object which has the main camera bound to it.

Headbobber.cs handles the head bobbing effect on the camera.

CrossFinder.cs creates a virtual crosshairs, and highlights interactable objects within a certain range of the character while they are under the crosshairs. If the player presses one of two interaction keys while an object is highlighted, it creates a dialogue string to output to QuipSupplier.

QuipSupplier.cs is applied to a GUI text element. When it is supplied text from CrossFinder, it displays the text, and clears that text after 5 seconds.
