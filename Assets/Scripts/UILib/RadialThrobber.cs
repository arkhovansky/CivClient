using UnityEngine;
using UnityEngine.UIElements;



namespace UILib
{
	public class RadialThrobber : VisualElement
	{
		public new class UxmlTraits : VisualElement.UxmlTraits
		{
			UxmlFloatAttributeDescription _phaseAttribute = new() {
				name = "phase"
			};

			public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
			{
				base.Init(ve, bag, cc);

				(ve as RadialThrobber)!.phase = _phaseAttribute.GetValueFromBag(bag, cc);
			}
		}

		public new class UxmlFactory : UxmlFactory<RadialThrobber, UxmlTraits> { }


		public static readonly string ussClassName = "radial-throbber";


		static CustomStyleProperty<Color> trackColor = new("--track-color");


		Color _color;

		float _phase;
		public float phase {
			get => _phase;
			set {
				_phase = value;
				MarkDirtyRepaint();
			}
		}



		public RadialThrobber()
		{
			AddToClassList(ussClassName);
			RegisterCallback<CustomStyleResolvedEvent>(CustomStylesResolved);
			generateVisualContent += GenerateVisualContent;
			phase = 0.0f;
		}



		static void CustomStylesResolved(CustomStyleResolvedEvent evt)
		{
			RadialThrobber element = (RadialThrobber)evt.currentTarget;
			element.UpdateCustomStyles();
		}

		void UpdateCustomStyles()
		{
			bool dirty = false;

			if (customStyle.TryGetValue(trackColor, out var color)) {
				dirty = (color != _color);
				_color = color;
			}

			if (dirty)
				MarkDirtyRepaint();
		}



		static void GenerateVisualContent(MeshGenerationContext context)
		{
			RadialThrobber throbber = (RadialThrobber)context.visualElement;
			throbber.Draw(context);
		}


		void Draw(MeshGenerationContext context)
		{
			var element = context.visualElement;
			var painter = context.painter2D;

			painter.lineWidth = 3f;
			painter.lineCap = LineCap.Round;
			painter.strokeColor = _color;
			painter.BeginPath();
			painter.Arc(element.contentRect.center, 7, Angle.Turns(phase), Angle.Turns(0.5f + phase));
			painter.Stroke();
		}
	}
}
