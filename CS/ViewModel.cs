using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataContextWpfSample {

    public class DataStoreViewModel {
        DataStoreModel dataStore;

        public DataStoreViewModel(DataStoreModel dataStore) {
            if (dataStore == null)
                throw new ArgumentNullException("dataStore");
            this.dataStore = dataStore;
        }
        public string ModelConnectionString { get { return dataStore.ConnectionString; } }
    }
}
