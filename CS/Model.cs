using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataContextWpfSample {
    public class DataStoreModel {
        public string ConnectionString { get; set; }

        public DataStoreModel(string connection) {
            ConnectionString = connection;
        }
    }
}
