# Game Engine 2 Assignment

## Assnigment requirements：

In this assignment, we will create a game that simulates the emergence of artificial life. The goal is to explore how simple rules and interactions between individual agents can give rise to complex and unpredictable behaviors at a system level.

To tie in the themes of John Conway, Alan Watts, Terence McKenna, Maths, and the Universe, you will be asked to incorporate the following elements:

Alan Watts: Consider how the concept of "wu-wei" (effortless action) can be applied to the behavior of the artificial life forms in your game. Can you create agents that exhibit emergent behaviors without needing to be explicitly programmed for them?

Terence McKenna: Use the concept of "novelty" to guide your approach to designing the rules and behaviors of the artificial life forms. How can you create a system that is always evolving and adapting to new challenges and opportunities?

Mathematics: Explore how mathematical concepts like chaos theory, fractals, cellular automata and boids can be used to model the behavior of the artificial life forms. Consider how different mathematical models can lead to different emergent behaviors.

The Universe: Think about how the behavior of the artificial life forms in your game relates to larger patterns and structures in the natural world. How can you create a system that reflects the complexity and interconnectedness of the universe?

## Discuss four theme around the game.

Alan Watts:
By applying the concept of wu-wei to the artificial life forms in your game, you can create agents that act spontaneously and effortlessly according to simple rules and interactions with their environment and other agents. Instead of programming them for specific outcomes, you can let them generate emergent behaviors that result from the collective dynamics of the system. This can make the game more interesting and challenging for the player, who has to adapt to the changing and unexpected situations that the agents create.

Terence McKenna: 
You can also use the concept of novelty to guide your approach to designing the rules and behaviors of the artificial life forms. You can create a system that is always evolving and adapting to new challenges and opportunities by introducing random or environmental factors that affect the agents’ survival and reproduction, such as predators, resources, climate, etc. You can also enable the agents to mutate, learn, communicate, cooperate, or compete with each other, depending on the situation. This can produce novel patterns and behaviors that are not predictable by the designer, but emerge from the interactions of the agents and their environment. This can make the game more engaging and immersive for the player, who has to explore and discover the different possibilities and outcomes that the system produces.

Mathematics: 
You can also model the behavior of the artificial life forms using these mathematical concepts by creating a system that combines cellular automata and boids. Cellular automata can represent the environment and the resources of the agents, such as food, water, obstacles, etc. Boids can represent the agents themselves, with different states and rules based on their characteristics, such as speed, size, vision, etc. You can also add chaos and fractals to the system by changing the initial conditions or the rules of the cellular automata or the boids, or by adding noise or feedback loops. This can create complex and diverse patterns and behaviors that emerge from the interactions of the cellular automata and the boids, rather than being predictable by the designer. This can make the game more realistic and captivating for the player, who has to observe and understand the dynamics of the system. 

The Universe:
Another way you can create a system that reflects the complexity and interconnectedness of the universe by using artificial life as a model. Artificial life is a field of study that explores and creates life-like systems using computational or synthetic methods. Artificial life systems can show properties such as self-organization, adaptation, evolution, emergence, and diversity. You can use artificial life techniques to create the artificial life forms in your game, such as cellular automata, genetic algorithms, neural networks, etc. You can also use artificial life principles to design the environment and the rules of the game, such as feedback loops, nonlinear dynamics, randomness, etc. This can make the system mimic the complexity and interconnectedness of the universe by generating lifelike patterns and behaviors that result from the interactions of the artificial life forms and their environment, rather than being predetermined by the designer. This can make the game more challenging and fascinating for the player, who has to cope with the unpredictability and diversity of the system. 


## Project describe:

A 3d game project:

I designed three artificial lives:  
1. Artificial small fish:  
Automatic random generation  
Follow the boids model to gather, move and avoid obstacles.  
According to the hunger value, it will leave the shoal of fish to prey on seaweed, and the hunger value is 35-50 random seconds.  
After each meal, feces are excreted at random events.  
After preying on seaweed for 5 times, it becomes an artificial big fish.  
Death when hunger value is 0.  

2. Artificial big fish:  
Artificial small fish preyed on artificial seaweed for 5 times and became artificial big fish.  
Follow the boids model to move and avoid obstacles.  
According to the hunger value, it will leave the shoal of fish to prey on small fish, and the hunger value is 35-50 random seconds.  
Death occurs when the hunger value is 0.  

3. Artificial seaweed:  
Automatic random generation 
Can be eaten by small fish for 5 times  
Replenishment to feces can add 5 times to be eaten.  

4. Players can move the observation by moving the mouse and clicking the WASD key.  

You can directly change various data in the code file, such as the number and time of fish generation.  

## Difficulties and Bugs:
Difficulties and errors encountered and solved:  
1. Small fish and big fish switch.  
2. What will fish do if food is eaten by others during predation?  
3. How to calculate the new boid group without reporting errors.  
4. The Boid logic may appear too close to the border and swim out directly.  

Problems that still exist:  
1. Two fish will twitch when they hit each other for prey food.  


## Demo video link:  

link


## Reference example source:  

A little experiment with boids in Unity:
https://www.youtube.com/watch?v=bqtqltqcQhw

For a much better implemented and performant version in Unity, have a look at the ECS sample project:
https://github.com/Unity-Technologies/EntityComponentSystemSamples/tree/master/ECSSamples/Assets/Advanced/Boids/Scripts
