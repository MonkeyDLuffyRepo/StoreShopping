using Omu.ValueInjecter.Injections;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Store.Infrastructure
{
    public class AvoidNullProps : LoopInjection
    {
        public AvoidNullProps() { }
        public AvoidNullProps(string[] ignoredProps) : base(ignoredProps) { }

        protected override void SetValue(object source, object target, PropertyInfo sp, PropertyInfo tp)
        {
            if (sp.GetValue(source) == null) return;
            base.SetValue(source, target, sp, tp);
        }
    }

    //public class AvoidNavigationProperties : LoopInjection
    //{
    //    public AvoidNavigationProperties() { }
    //    public AvoidNavigationProperties(string[] ignoredProps) : base(ignoredProps) { }

    //    private bool IsToMap(Type type)
    //    {
    //        var dalNameSpace = typeof(Olympus.Entity.Opportunity).Namespace;
    //        return type.Namespace != dalNameSpace && !(type.IsGenericType && type.GenericTypeArguments[0].Namespace == dalNameSpace);
    //    }

    //    protected override void SetValue(object source, object target, PropertyInfo sp, PropertyInfo tp)
    //    {
    //        var val = sp.GetValue(source);

    //        if (val != null && IsToMap(sp.PropertyType))
    //            tp.SetValue(target, val);
    //    }
    //}

    public class AnyToStrInjection : LoopInjection
    {
        protected override bool MatchTypes(Type source, Type target)
        {
            if (source == typeof(DateTime) || source == typeof(DateTime?))
            {
                return true;
            }
            return base.MatchTypes(source, target);
        }
        protected override void SetValue(object source, object target, PropertyInfo sp, PropertyInfo tp)
        {
            if (sp.PropertyType == typeof(bool) || sp.PropertyType == typeof(bool?))
            {
                tp.SetValue(target, Convert.ToBoolean(sp.GetValue(source)));
                return;
            }

            if (sp.PropertyType != tp.PropertyType)
            {
                tp.SetValue(target, Convert.ToString(sp.GetValue(source)));
                return;
            }

            base.SetValue(source, target, sp, tp);
        }
    }

}
