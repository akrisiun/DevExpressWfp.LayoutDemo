﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Diagnostics;
using DevExpress.Xpf.LayoutControl;
using System.ComponentModel.DataAnnotations;

namespace DevExpress.Xpf.LayoutControlDemo
{

    public class DataControlPageViewModel
    {
        public class ObjectNamePair
        {
            public string Name { get; private set; }
            public object Obj { get; private set; }

            public Type Type { get; set; }
            public string Path { get; set; }

            public ObjectNamePair(string name, object obj)
            {
                this.Name = name;
                this.Obj = obj;
            }

            public override string ToString()
            {
                return $"{Name} : {Obj}";
            }

        }
        public IEnumerable<ObjectNamePair> ObjectList { get; private set; }

        public virtual ObjectNamePair SelectedObject {
            get;
            set;
        }

        public static Action<DataControlPageViewModel, ObjectNamePair> OnChanged { get; set; }

        public DataControlPageViewModel()
        {
            // Debugger.Break();
            #region Seeds

            var supportedDataTypes = new SupportedDataTypesData
            {
                IntProperty = 123,
                NullableIntProperty = 4567,
                DoubleProperty = 12345.12345,
                NullableDoubleProperty = 6789.6789,
                BoolProperty = true,
                CharProperty = 'Y',
                NullableCharProperty = 'N',
                NullableEnumProperty = Gender.Female,
                StringProperty = "text",
                DateTimeProperty = DateTime.Today,
                NullableDateTimeProperty = DateTime.Today.AddDays(1),
                DecimalProperty = 12345.12345m,
                NullableDecimalProperty = 789.789m,
                ComplexTypeProperty = new Point(123.45, 678.9),
                CurrencyProperty = 1234567.89m,
                MultilineTextProperty = "first line of text\r\nsecond line of text\r\nthird line of text",
                PasswordProperty = "password",
                PhoneNumberProperty = "1234567890"
            };
            var supportedDataTypes_FluentAPI = new SupportedDataTypesData_FluentAPI
            {
                IntProperty = 123,
                NullableIntProperty = 4567,
                DoubleProperty = 12345.12345,
                NullableDoubleProperty = 6789.6789,
                BoolProperty = true,
                CharProperty = 'Y',
                NullableCharProperty = 'N',
                NullableEnumProperty = Gender.Female,
                StringProperty = "text",
                DateTimeProperty = DateTime.Today,
                NullableDateTimeProperty = DateTime.Today.AddDays(1),
                DecimalProperty = 12345.12345m,
                NullableDecimalProperty = 789.789m,
                ComplexTypeProperty = new Point(123.45, 678.9),
                CurrencyProperty = 1234567.89m,
                MultilineTextProperty = "first line of text\r\nsecond line of text\r\nthird line of text",
                PasswordProperty = "password",
                PhoneNumberProperty = "1234567890"
            };
            var attributeSupport = new AttributeSupportData
            {
                ID = 123456,
                FirstName = "Steve",
                LastName = "Jobs",
                Age = 56,
                Gender = Gender.Male,
                Employer = "Apple Inc",
                SSN = "123-45-6789"
            };
            var attributeSupport_FluentAPI = new AttributeSupportData_FluentAPI
            {
                ID = 123456,
                FirstName = "Steve",
                LastName = "Jobs",
                Age = 56,
                Gender = Gender.Male,
                Employer = "Apple Inc",
                SSN = "123-45-6789"
            };
            var maskedInput = new MaskedInputData
            {
                PercentProperty = 0.42,
                PercentMultBy100Property = 0.42,
                CurrencyProperty = 499.90m,
                EuroCurrencyProperty = 399.90m,
                NumberProperty = 1234567.89,
                FixedPointProperty = 9876543.21,
                Decimal4DigitsProperty = 17,
                CustomNumericMaskPropery1 = 3080.6,
                CustomNumericMaskPropery2 = -3080.6,
                PhoneProperty = "555-12-34",
                ShortZipCodeProperty = "12345",
                LongZipCodeProperty = "12345-6789",
                SocialSequrityProperty = "123-45-6789",
            };
            AssignDateTimeProperties(maskedInput);
            var maskedInput_FluentAPI = new MaskedInputData_FluentAPI
            {
                PercentProperty = 0.42,
                PercentMultBy100Property = 0.42,
                CurrencyProperty = 499.90m,
                EuroCurrencyProperty = 399.90m,
                NumberProperty = 1234567.89,
                FixedPointProperty = 9876543.21,
                Decimal4DigitsProperty = 17,
                CustomNumericMaskPropery1 = 3080.6,
                CustomNumericMaskPropery2 = -3080.6,
                PhoneProperty = "555-12-34",
                ShortZipCodeProperty = "12345",
                LongZipCodeProperty = "12345-6789",
                SocialSequrityProperty = "123-45-6789",
            };
            AssignDateTimeProperties(maskedInput_FluentAPI);
            var groupedLayout = new GroupedLayoutData
            {
                FirstName = "Anita",
                LastName = "Benson",
                Group = "Inventory Management",
                Title = "Purchasing Manager",
                HireDate = new DateTime(2002, 2, 2),
                Salary = 65000m,
                Phone = "7138638137",
                Email = "Anita_Benson@example.com",
                AddressLine1 = "9602 South Main",
                AddressLine2 = "Seattle, 77025, USA",
                Gender = Gender.Female,
                BirthDate = new DateTime(1985, 3, 18)
            };
            var groupedLayout_FluentAPI = new GroupedLayoutData_FluentAPI
            {
                FirstName = "Anita",
                LastName = "Benson",
                Group = "Inventory Management",
                Title = "Purchasing Manager",
                HireDate = new DateTime(2002, 2, 2),
                Salary = 65000m,
                Phone = "7138638137",
                Email = "Anita_Benson@example.com",
                AddressLine1 = "9602 South Main",
                AddressLine2 = "Seattle, 77025, USA",
                Gender = Gender.Female,
                BirthDate = new DateTime(1985, 3, 18)
            };
            var advancedGroupedLayout = new AdvancedGroupedLayoutData
            {
                FirstName = "Anita",
                LastName = "Benson",
                Group = "Inventory Management",
                Title = "Purchasing Manager",
                HireDate = new DateTime(2002, 2, 2),
                Salary = 65000m,
                Phone = "7138638137",
                Email = "Anita_Benson@example.com",
                AddressLine1 = "9602 South Main",
                AddressLine2 = "Seattle, 77025, USA",
                Gender = Gender.Female,
                BirthDate = new DateTime(1985, 3, 18)
            };
            var advancedGroupedLayout_FluentAPI = new AdvancedGroupedLayoutData_FluentAPI
            {
                FirstName = "Anita",
                LastName = "Benson",
                Group = "Inventory Management",
                Title = "Purchasing Manager",
                HireDate = new DateTime(2002, 2, 2),
                Salary = 65000m,
                Phone = "7138638137",
                Email = "Anita_Benson@example.com",
                AddressLine1 = "9602 South Main",
                AddressLine2 = "Seattle, 77025, USA",
                Gender = Gender.Female,
                BirthDate = new DateTime(1985, 3, 18)
            };

            #endregion

            SelectedObject = new ObjectNamePair("Advanced grouped layout (Fluent API)", advancedGroupedLayout_FluentAPI)
            {
                Type = typeof(AdvancedGroupedLayoutData_FluentAPI),
                Path = "AdvancedGroupedLayoutData_FluentAPI.cs"
            };

            ObjectList = new ObjectNamePair[] {
                    new ObjectNamePair("Supported data types", supportedDataTypes)
                    {
                        Type = typeof(SupportedDataTypesData),
                        Path = "SupportedDataTypesData.cs"
                    },
                    new ObjectNamePair("Supported data types (Fluent API)", supportedDataTypes_FluentAPI)
                    {
                        Type = typeof(SupportedDataTypesData_FluentAPI),
                        Path = "SupportedDataTypesData_FluentAPI.cs"
                    }
                    ,
                    new ObjectNamePair("Attribute support", attributeSupport)
                    {
                        Type = typeof(AttributeSupportData),
                        Path = "AttributeSupportData.cs"
                    }
                    ,
                    new ObjectNamePair("Attribute support (Fluent API)", attributeSupport_FluentAPI)
                    {
                        Type = typeof(AdvancedGroupedLayoutData_FluentAPI),
                        Path = "AdvancedGroupedLayoutData_FluentAPI.cs"
                    }
                    ,
                    new ObjectNamePair("Masked input", maskedInput)
                    {
                        Type = typeof(MaskedInputData),
                        Path = "MaskedInputData.cs"
                    }
                    ,
                    new ObjectNamePair("Masked input (Fluent API)", maskedInput_FluentAPI)
                    {
                        Type = typeof(MaskedInputData_FluentAPI),
                        Path = "MaskedInputData_FluentAPI.cs"
                    }
                    ,
                    new ObjectNamePair("Grouped layout", groupedLayout)
                    {
                        Type = typeof(GroupedLayoutData),
                        Path = "GroupedLayoutData.cs"
                    }
                    ,
                    new ObjectNamePair("Grouped layout (Fluent API)", groupedLayout_FluentAPI)
                    {
                        Type = typeof(GroupedLayoutData_FluentAPI),
                        Path = "GroupedLayoutData_FluentAPI.cs"
                    }
                    ,
                    new ObjectNamePair("Advanced grouped layout", advancedGroupedLayout)
                    {
                        Type = typeof(AdvancedGroupedLayoutData),
                        Path = "AdvancedGroupedLayoutData.cs"
                    },
                    SelectedObject,
                };
        }

        static void AssignDateTimeProperties(object obj)
        {
            foreach (var property in obj.GetType().GetProperties().Where(x => x.PropertyType == typeof(DateTime)))
            {
                property.SetValue(obj, DateTime.Now, null);
            }
        }
    }
}
