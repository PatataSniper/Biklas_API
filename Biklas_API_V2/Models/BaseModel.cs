using System;

namespace Biklas_API_V2.Models
{
    public abstract class BaseModel
    {
        private BiklasEntities _db;

        #region Constructores
        public BaseModel()
        {

        }

        public BaseModel(BiklasEntities db)
        {
            _db = db;
        }
        #endregion

        public BiklasEntities Db
        {
            get
            {
                if(_db == null)
                {
                    _db = new BiklasEntities();
                }

                return _db;
            }
            set
            {
                _db = value;
            }
        }
    }
}