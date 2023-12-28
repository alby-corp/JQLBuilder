﻿namespace JQLBuilder.Global;

using Types.Custom;
using Types.Primitive;

public class CustomFields
{
        public CustomDate Date { get; } = new();
        
        public class CustomDate : CustomFields
        {
            public Date this[string field] => Field.Custom<Date>(field);
            public Date this[int field] => Field.Custom<Date>($"cf[{field}]");
        
            public  Date Now => Field.Custom<Date>("now()"); 
            public  Date CurrentLogin => Field.Custom<Date>("currentLogin()"); 
            public  Date LastLogin => Field.Custom<Date>("lastLogin()"); 
            public  Date StartOfDay(int value) => Field.Custom<Date>("startOfDay(${value})");
            public  Date StartOfWeek(int value) => Field.Custom<Date>($"startOfWeek({value})");
            public  Date StartOfMonth(int value) => Field.Custom<Date>($"startOfMonth({value})");
            public  Date StartOfYear(int value) => Field.Custom<Date>($"startOfYear({value})");
            public  Date EndOfDay(int value) => Field.Custom<Date>($"endOfDay({value})");
            public  Date EndOfWeek(int value) => Field.Custom<Date>($"endOfWeek({value})");
            public  Date EndOfMonth(int value) => Field.Custom<Date>($"endOfMonth({value})");
            public  Date EndOfYear(int value) => Field.Custom<Date>($"endOfYear({value})");   
        }
}