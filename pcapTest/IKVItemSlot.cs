using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace pcapTest
{
	public enum IKVSlotType
	{
		hidden,
		equipment,
		backPack,
		bank
	}
	public class IKVItemSlot : INotifyPropertyChanged
	{
		public IKVItemSlot(int slot, IKVItem item, IKVSlotType slotType)
		{
			this.slot = slot;
			this.item = item;
			this.slotType = slotType;
		}

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		}

		public IKVItem Item
		{
			get { return item; } 
			set {
				if(item == null || !item.Equals(value))
				{
					item = value;
					NotifyPropertyChanged();

				}
			} 
		}
		public int Slot { 
			get { return slot; }
			set {
				slot = value;
			} 
		}

		private int slot;
		private IKVSlotType slotType;
		private IKVItem item;

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
