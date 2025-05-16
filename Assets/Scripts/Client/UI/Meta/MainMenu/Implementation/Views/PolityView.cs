using System;
using Client.UI.Meta.Common.Interface;
using Common.Domain.Meta.GameSpecification;
using UnityEngine.UIElements;



namespace Client.UI.Meta.MainMenu.Implementation.Views
{
	public abstract class PolityView : IPolityView
	{
		protected readonly TextElement element;

		protected readonly IPolityVM vm;



		protected PolityView(TextElement element, IPolityVM vm)
		{
			this.element = element;
			this.vm = vm;
		}



		public virtual void Render()
		{
			element.text = FormatBaseName(vm.Polity);
		}



		protected virtual string FormatBaseName(IPolitySpecification polity)
		{
			return polity.Name.BaseName switch {
				PresetName_PolityBaseNameSpecification => FormatPresetName(polity.Kind),
				CustomName_PolityBaseNameSpecification customNameSpec => customNameSpec.CustomName,
				_ => throw new Exception()
			};
		}


		protected abstract string FormatPresetName(IPolityKindSpecification kind);
	}
}
