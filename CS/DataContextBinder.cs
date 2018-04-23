using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace DataContextWpfSample {

    public interface IDataContextOwner {
        object DataContext { get; }
        void UpdateInnerDataContext(object dataContext);
    }

    public class DataContextBinder : DependencyObject {
        IDataContextOwner owner;
        public DataContextBinder(IDataContextOwner owner) {
            if (owner == null)
                throw new ArgumentNullException("owner");
            this.owner = owner;

            InitializeBinding();
        }
        protected virtual void InitializeBinding() {
            Binding binding = new Binding("DataContext");
            binding.Source = owner;
            binding.Mode = BindingMode.OneWay;

            BindingOperations.SetBinding(this, DataContextProperty, binding);
        }
        public object DataContext {
            get { return (object)GetValue(DataContextProperty); }
            set { SetValue(DataContextProperty, value); }
        }
        public static readonly DependencyProperty DataContextProperty =
            DependencyProperty.Register("DataContext", typeof(object), typeof(DataContextBinder), new PropertyMetadata(null, new PropertyChangedCallback(OnDataContextChanged)));

        public static void OnDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((DataContextBinder)d).OnDataContextChanged(e.OldValue, e.NewValue);
        }
        private void OnDataContextChanged(object oldValue, object newValue) {
            owner.UpdateInnerDataContext(newValue);
        }
    }

}
