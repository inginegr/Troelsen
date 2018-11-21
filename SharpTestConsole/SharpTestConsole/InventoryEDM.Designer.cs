﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace SharpTestConsole
{
    #region Контексты
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    public partial class AutoLotEntities : ObjectContext
    {
        #region Конструкторы
    
        /// <summary>
        /// Инициализирует новый объект AutoLotEntities, используя строку соединения из раздела "AutoLotEntities" файла конфигурации приложения.
        /// </summary>
        public AutoLotEntities() : base("name=AutoLotEntities", "AutoLotEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта AutoLotEntities.
        /// </summary>
        public AutoLotEntities(string connectionString) : base(connectionString, "AutoLotEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта AutoLotEntities.
        /// </summary>
        public AutoLotEntities(EntityConnection connection) : base(connection, "AutoLotEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Разделяемые методы
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Свойства ObjectSet
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<Car> Cars
        {
            get
            {
                if ((_Cars == null))
                {
                    _Cars = base.CreateObjectSet<Car>("Cars");
                }
                return _Cars;
            }
        }
        private ObjectSet<Car> _Cars;

        #endregion

        #region Методы AddTo
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet Cars. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToCars(Car car)
        {
            base.AddObject("Cars", car);
        }

        #endregion

    }

    #endregion

    #region Сущности
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AutoLotModel", Name="Car")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Car : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Car.
        /// </summary>
        /// <param name="carID">Исходное значение свойства CarID.</param>
        public static Car CreateCar(global::System.Int32 carID)
        {
            Car car = new Car();
            car.CarID = carID;
            return car;
        }

        #endregion

        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 CarID
        {
            get
            {
                return _CarID;
            }
            set
            {
                if (_CarID != value)
                {
                    OnCarIDChanging(value);
                    ReportPropertyChanging("CarID");
                    _CarID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("CarID");
                    OnCarIDChanged();
                }
            }
        }
        private global::System.Int32 _CarID;
        partial void OnCarIDChanging(global::System.Int32 value);
        partial void OnCarIDChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Make
        {
            get
            {
                return _Make;
            }
            set
            {
                OnMakeChanging(value);
                ReportPropertyChanging("Make");
                _Make = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Make");
                OnMakeChanged();
            }
        }
        private global::System.String _Make;
        partial void OnMakeChanging(global::System.String value);
        partial void OnMakeChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Color
        {
            get
            {
                return _Color;
            }
            set
            {
                OnColorChanging(value);
                ReportPropertyChanging("Color");
                _Color = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Color");
                OnColorChanged();
            }
        }
        private global::System.String _Color;
        partial void OnColorChanging(global::System.String value);
        partial void OnColorChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String CarNickName
        {
            get
            {
                return _CarNickName;
            }
            set
            {
                OnCarNickNameChanging(value);
                ReportPropertyChanging("CarNickName");
                _CarNickName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("CarNickName");
                OnCarNickNameChanged();
            }
        }
        private global::System.String _CarNickName;
        partial void OnCarNickNameChanging(global::System.String value);
        partial void OnCarNickNameChanged();

        #endregion

    
    }

    #endregion

    
}
