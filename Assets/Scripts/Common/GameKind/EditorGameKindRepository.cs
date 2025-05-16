// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Reflection;
// using Common.Domain.Game;
//
//
//
// namespace Common.GameKind
// {
// 	public class EditorGameKindRepository : IGameKindRepository
// 	{
// 		private readonly Dictionary<Guid, IGameKind> _gameTypes = new();
//
//
//
// 		public EditorGameKindRepository()
// 		{
// 			string thisPath = Assembly.GetExecutingAssembly().Location;
// 			string directoryPath = Path.GetDirectoryName(thisPath)!;
//
// 			string path = Path.Combine(directoryPath, "FreeCiv.Client.dll");
// 			Assembly assembly = Assembly.LoadFrom(path);
//
// 			Type? gameTypeType = Array.Find(assembly.GetExportedTypes(), type => type.Name == "GameKind");
// 			if (gameTypeType == null)
// 				throw new Exception();
//
// 			PropertyInfo? idProperty = gameTypeType.GetProperty("Id", typeof(Guid));
// 			if (idProperty == null)
// 				throw new Exception();
//
// 			Guid id = (Guid)idProperty.GetValue(null);
//
// 			_gameTypes.Add(id, new GameKind {
// 				Id = id,
// 				Assembly = assembly
// 			});
// 		}
//
//
//
// 		public IGameKind? Get(Guid id)
// 		{
// 			return _gameTypes.GetValueOrDefault(id);
// 		}
// 	}
// }
