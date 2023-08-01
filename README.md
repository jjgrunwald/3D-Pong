# 3D-Pong
by J.J. Grunwald

This is a 3D Pong game which I created for my final project in Programming Fundamentals II class. I completed an isometric perspective game for my final project in my first Programming Fundamentals class, and initially I had planned to create a pong game from an isometric perspective. My instructor was very supportive of my initial idea and had motivated me to attempt to create a fully 3D game, rather than simply creating the illusion of 3D with isometric graphics. I want to thank my instructor in Programming Fundamentals for his help with realizing this project.

The game was created in C## and uses mostly primitive graphics, and some minor art assets which I created (such as the title, icon file, keyboard layout graphics, etc.). The 3D works using a class named “Vector” which allows for the input of the X, Y and Z coordinates. A 3D perspective of these shapes is then calculated using a 3x3 Perspective Matrix consisting of 9 different matrices, which is also a separate class. The paddle, ball, and score are all also separate classes, and a final class titled “Referee” acts as the referee for the game.
