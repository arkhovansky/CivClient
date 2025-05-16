[In progress] [Does not compile]

Experimental prototype of a client - server 4X game on Unity.

Currently only UI and infrastructure code.

Used features:
- Multiple assemblies
- UI Toolkit (also using Vector API for drawing elements)

Custom features:
- MVVM system
- UI framework organizing screens as a hierarchy of components (controllers)
- Modding infrastructure: DI container resolving by semantic properties (e.g. "resolve 'main menu' controller")
- Currently, there is no actual client-server API, server stub is called directly
