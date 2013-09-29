﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CKCompiler.Core.ObjectDefs
{
    public class FieldObjectDef : ObjectDef
    {
        public string Name;
        public FieldInfo FieldInfo;

        public FieldObjectDef(Type type, string name)
            : base(type)
        {
            Name = name;
        }

        public FieldObjectDef(Type type, string name, FieldInfo fieldInfo)
            : base(type)
        {
            Name = name;
            FieldInfo = fieldInfo;
        }

        public override enmObjectScope Scope
        {
            get
            {
                return enmObjectScope.Field;
            }
        }

        public override void Load()
        {
            if (!FieldInfo.IsStatic)
            {
                Generator.Emit(OpCodes.Ldarg_0);
                Generator.Emit(OpCodes.Ldfld, FieldInfo);
            }
            else
            {
                Generator.Emit(OpCodes.Ldsfld, FieldInfo);
            }
        }

        public override void Remove()
        {
        }

        public override void Free()
        {
        }
    }
}
