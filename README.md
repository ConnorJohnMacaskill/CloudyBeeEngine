# Introduction
An [ECS](https://en.wikipedia.org/wiki/Entity_component_system) engine written using the C# Monogame framework, lovingly named CloudyBee. I never really used it for anything but enjoyed developing it and learnt a lot about the concept.

# Structure

The engine logic is centralised in the CloudyBeeEngine project, an example "game" using the engine is implemented in the TurretArena project.

# Assets & Entities

Assets are stored externally and loaded at runtime for easy modification, including entities which are stored as XML files and built up using predefined components, an example of which can be found in SentryTurret.xml.
