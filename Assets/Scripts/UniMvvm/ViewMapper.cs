using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine.UIElements;
using Util;



namespace UniMvvm
{
	public static class ViewMapper
	{
		public static void Map(VisualElement rootElement, object viewModel)
		{
			(new Mapper(rootElement, viewModel)).Map();
		}



		private class Mapper
		{
			private VisualElement _rootElement;
			private object _viewModel;



			public Mapper(VisualElement rootElement, object viewModel)
			{
				_rootElement = rootElement;
				_viewModel = viewModel;
			}


			public void Map()
			{
				Type type = _viewModel.GetType();
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

				foreach (var property in properties) {
					if (property.PropertyType == typeof(string)) {
						VisualElement? matchingElement = FindMatchingElement(property.Name, IsTextElement);

						if (matchingElement != null)
							MapStatic((TextElement)matchingElement, (string)property.GetValue(_viewModel));
						// else
					}
					// else if (property.PropertyType == typeof(ButtonVM)) {
					// 	VisualElement? matchingElement = FindMatchingElement(property.Name, IsButton);
					//
					// 	if (matchingElement != null) {
					// 		((Button)matchingElement).BindViewModel((ButtonVM)property.GetValue(_viewModel));
					// 	}
					// 	// else
					// }
					else if (typeof(ICommand).IsAssignableFrom(property.PropertyType)) {
						string nameBase = property.Name.TrimSuffix("Command") + "Button";
						var names = new string[] { nameBase, nameBase + "Button", nameBase + "Command" };

						VisualElement? matchingElement = FindMatchingElement(names, IsButton);

						if (matchingElement != null) {
							((Button)matchingElement).BindCommand((ICommand)property.GetValue(_viewModel));
						}
						// else
					}
					else if (property.PropertyType.IsClass) {
						string elementName = property.Name.TrimSuffix("VM");
						var elementNames = new string[] {elementName, elementName + "block"};

						VisualElement? matchingElement = FindMatchingElement(elementNames, IsContainer);

						if (matchingElement != null) {
							var value = property.GetValue(_viewModel);
							if (value != null)
								ViewMapper.Map(matchingElement, value);
							else
								matchingElement.style.display = DisplayStyle.None;
						}
						else {
						}
					}
				}

			}


			private VisualElement? FindMatchingElement(string propertyName, Predicate<VisualElement> filter)
			{
				return FindMatchingElement(_rootElement, new string[]{propertyName}, filter);
			}


			private VisualElement? FindMatchingElement(IReadOnlyList<string> names, Predicate<VisualElement> filter)
			{
				return FindMatchingElement(_rootElement, names, filter);
			}


			private VisualElement? FindMatchingElement(
				VisualElement element, IReadOnlyList<string> names, Predicate<VisualElement> filter)
			{
				if (filter(element) && NamesMatch(element.name, names))
					return element;

				foreach (var child in element.Children()) {
					var matchingElement = FindMatchingElement(child, names, filter);

					if (matchingElement != null)
						return matchingElement;
				}

				return null;
			}


			private bool IsTextElement(VisualElement element)
			{
				Type type = element.GetType();

				if (typeof(TextElement).IsAssignableFrom(type))
					return true;

				return false;
			}


			private bool IsButton(VisualElement element)
			{
				Type type = element.GetType();

				if (type == typeof(Button))
					return true;

				return false;
			}


			private bool IsContainer(VisualElement element)
			{
				Type type = element.GetType();

				if (type == typeof(VisualElement))
					return true;

				return false;
			}



			private static bool NamesMatch(string elementName, IReadOnlyList<string> names)
			{
				return names.Any(name => NamesMatch(elementName, name));
			}


			private static bool NamesMatch(string elementName, string name)
			{
				return elementName.Equals(name, StringComparison.OrdinalIgnoreCase);
			}



			private void MapStatic(VisualElement element, string text)
			{
				((TextElement)element).text = text;
			}
		}
	}
}
