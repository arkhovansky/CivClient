// using System;
// using System.Collections.Generic;
// using UniRx;
//
//
//
// namespace Client.UI.Meta
// {
// 	public class SingleSelectionListVM<TItem>
// 	{
// 		public class Data
// 		{
// 			public IReadOnlyList<TItem> list;
// 			public int selectedIndex;
//
// 			public Data() {
// 				list = new List<TItem>();
// 				selectedIndex = -1;
// 			}
//
// 			public Data(IReadOnlyList<TItem> list, int selectedIndex) {
// 				this.list = list;
// 				this.selectedIndex = selectedIndex;
// 			}
// 		}
//
//
// 		public BehaviorSubject<Data> ThisData { get; }
//
// 		public BehaviorSubject<IReadOnlyList<TItem>> List { get; }
// 		public BehaviorSubject<int> SelectedIndex { get; }
//
//
//
// 		public SingleSelectionListVM(Data data)
// 		{
// 			ThisData = new BehaviorSubject<Data>(new Data());
//
// 			List = new BehaviorSubject<IReadOnlyList<TItem>>(null);
// 			ThisData.Select(data => data.list).Subscribe(List);
//
// 			SelectedIndex = new BehaviorSubject<int>(-1);
// 			ThisData.Select(data => data.selectedIndex).Subscribe(SelectedIndex);
// 		}
//
//
//
// 		public SingleSelectionListVM(IObservable<Data> data)
// 			: this(new Data())
// 		{
// 			data.Subscribe(ThisData);
// 		}
//
//
//
// 		// public void Clear()
// 		// {
// 		// 	if (!List.HasValue || List.Value.Count > 0)
// 		// 		List.SetValue(new List<TItem>());
// 		// 	SelectedIndex.SetValue(-1);
// 		// }
// 	}
// }
