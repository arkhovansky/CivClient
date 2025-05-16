// using System.Collections.Generic;
// using System.Linq;
// using Application.Service.Interface;
// using Domain;
//
//
//
// namespace Application.Service.Implementation
// {
// 	public class WorldCreator : IWorldCreator
// 	{
// 		public World CreateWorld(WorldSpecification config)
// 		{
// 			Terrain terrain = CreateTerrain(config.TerrainConfiguration);
//
// 			World world = new World(terrain);
//
// 			IReadOnlyList<Location> startLocations = FindStartLocations(terrain, config.Nations);
//
// 			IList<Nation> nations = config.Nations.Zip(startLocations, (nationConfiguration, startLocation) => {
// 				Nation nation = new Nation(
// 					nationConfiguration.NationType.Name,
// 					nationConfiguration.Leader,
// 					new WorldKnowledge(world));
//
// 				CreateStartUnits(nation, startLocation);
//
// 				return nation;
// 			}).ToList();
//
// 			world.Nations = nations;
//
// 			return world;
// 		}
//
//
//
// 		private Terrain CreateTerrain(TerrainConfiguration config)
// 		{
//
// 		}
//
//
//
// 		private static IReadOnlyList<Location> FindStartLocations(
// 			Terrain terrain,
// 			IList<NationConfiguration> nations)
// 		{
//
// 		}
//
//
//
// 		private void CreateStartUnits(Nation nation, Location location)
// 		{
// 			Unit settler = UnitFactory.Create("Settler", location);
// 			nation.AddUnit(settler);
// 		}
// 	}
// }
