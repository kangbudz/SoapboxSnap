#region "SoapBox.Protocol License"
/// <header module="SoapBox.Protocol"> 
/// Copyright (C) 2010 SoapBox Automation, All Rights Reserved.
/// Contact: SoapBox Automation Licencing (license@soapboxautomation.com)
/// 
/// This file is part of SoapBox Protocol.
///
/// SoapBox Protocol is available under your choice of these licenses:
///  - GPLv3
///  - CDDLv1.0
///
/// GNU General Public License Usage
/// SoapBox Protocol is free software: you can redistribute it and/or modify it
/// under the terms of the GNU General Public License as published by the 
/// Free Software Foundation, either version 3 of the License, or 
/// (at your option) any later version.
/// 
/// SoapBox Protocol is distributed in the hope that it will be useful, but 
/// WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU General Public License for more details.
/// 
/// You should have received a copy of the GNU General Public License along
/// with SoapBox Protocol. If not, see <http://www.gnu.org/licenses/>.
/// 
/// Common Development and Distribution License Usage
/// SoapBox Protocol is subject to the CDDL Version 1.0. 
/// You should have received a copy of the CDDL Version 1.0 along
/// with SoapBox Protocol.  If not, see <http://www.sun.com/cddl/cddl.html>.
/// The CDDL is a royalty free, open source, file based license.
/// </header>
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SoapBox.Utilities;
using SoapBox.Protocol.Base;

namespace SoapBox.Protocol.Automation
{
    /// <summary>
    /// Represents a Analog output on a device
    /// </summary>
    public sealed class NodeAnalogOutput : NodeBase
    {

        /// <summary>
        /// The value that should be output to the actual hardware
        /// and takes the forced status into account.  Threadsafe.
        /// </summary>
        public Decimal GetValue(NodeRuntimeApplication runtimeApplication)
        {
            if (runtimeApplication == null)
            {
                throw new ArgumentNullException();
            }
            if (Forced.BoolValue)
            {
                return (Decimal)ForcedValue.Value;
            }
            else
            {
                var nValue = SignalIn.GetValue(runtimeApplication);
                if (nValue != null && nValue.DataType.DataType == FieldDataType.DataTypeEnum.NUMBER)
                {
                    return (Decimal)nValue.Value;
                }
                else
                {
                    return (Decimal)FieldDataType.DefaultValue(FieldDataType.DataTypeEnum.NUMBER);
                }
            }
        }

        #region " FIELDS "

        #region " Code (FieldIdentifier) "
        public FieldIdentifier Code
        {
            get
            {
                return (FieldIdentifier)Fields[new FieldIdentifier(m_CodeName)];
            }
        }
        public NodeAnalogOutput SetCode(FieldIdentifier Code)
        {
            if (Code == null)
            {
                throw new ArgumentNullException(m_CodeName);
            }
            return new NodeAnalogOutput(this.SetField(new FieldIdentifier(m_CodeName), Code), ChildCollection);
        }
        static readonly string m_CodeName =
            NotifyPropertyChangedHelper.GetPropertyName<NodeAnalogOutput>(o => o.Code);
        #endregion
        
        #region " Address (FieldString) "
        public FieldString Address
        {
            get
            {
                return (FieldString)Fields[new FieldIdentifier(m_AddressName)];
            }
        }
        public NodeAnalogOutput SetAddress(FieldString Address)
        {
            if (Address == null)
            {
                throw new ArgumentNullException(m_AddressName);
            }
            return new NodeAnalogOutput(this.SetField(new FieldIdentifier(m_AddressName), Address), ChildCollection);
        }
        static readonly string m_AddressName =
            NotifyPropertyChangedHelper.GetPropertyName<NodeAnalogOutput>(o => o.Address);
        #endregion
        
        #region " Forced (FieldBool) "
        public FieldBool Forced
        {
            get
            {
                return (FieldBool)Fields[new FieldIdentifier(m_ForcedName)];
            }
        }
        public NodeAnalogOutput SetForced(FieldBool Forced)
        {
            if (Forced == null)
            {
                throw new ArgumentNullException(m_ForcedName);
            }
            return new NodeAnalogOutput(this.SetField(new FieldIdentifier(m_ForcedName), Forced), ChildCollection);
        }
        static readonly string m_ForcedName =
            NotifyPropertyChangedHelper.GetPropertyName<NodeAnalogOutput>(o => o.Forced);
        #endregion
        
        #region " ForcedValue (FieldConstant) "
        public FieldConstant ForcedValue
        {
            get
            {
                return (FieldConstant)Fields[new FieldIdentifier(m_ForcedValueName)];
            }
        }
        public NodeAnalogOutput SetForcedValue(FieldConstant ForcedValue)
        {
            if (ForcedValue == null)
            {
                throw new ArgumentNullException(m_ForcedValueName);
            }
            return new NodeAnalogOutput(this.SetField(new FieldIdentifier(m_ForcedValueName), ForcedValue), ChildCollection);
        }
        static readonly string m_ForcedValueName =
            NotifyPropertyChangedHelper.GetPropertyName<NodeAnalogOutput>(o => o.ForcedValue);
        #endregion
        
        #region " SignalIn (NodeSignalIn) "
        private readonly SingleChild<NodeSignalIn, NodeAnalogOutput> m_SignalIn = null;
        public NodeSignalIn SignalIn
        {
            get
            {
                return m_SignalIn.Item;
            }
        }
        public NodeAnalogOutput SetSignalIn(NodeSignalIn NewSignalIn)
        {
            if (NewSignalIn == null)
            {
                throw new ArgumentNullException(m_SignalInName);
            }
            return m_SignalIn.Set(NewSignalIn);
        }
        static readonly string m_SignalInName =
            NotifyPropertyChangedHelper.GetPropertyName<NodeAnalogOutput>(o => o.SignalIn);
        #endregion
        
        #region " OutputName (FieldSignalName) "
        public FieldSignalName OutputName
        {
            get
            {
                return (FieldSignalName)Fields[new FieldIdentifier(m_OutputNameName)];
            }
        }
        public NodeAnalogOutput SetOutputName(FieldSignalName OutputName)
        {
            if (OutputName == null)
            {
                throw new ArgumentNullException(m_OutputNameName);
            }
            return new NodeAnalogOutput(this.SetField(new FieldIdentifier(m_OutputNameName), OutputName), ChildCollection);
        }
        static readonly string m_OutputNameName =
            NotifyPropertyChangedHelper.GetPropertyName<NodeAnalogOutput>(o => o.OutputName);
        #endregion

        #endregion

        #region " CONSTRUCTORS "
        private NodeAnalogOutput(ReadOnlyDictionary<FieldIdentifier, FieldBase> Fields,
            ReadOnlyCollection<NodeBase> Children)
            : base(Fields, Children)
        {
            m_SignalIn = new SingleChild<NodeSignalIn, NodeAnalogOutput>(this);

            // Validation
            if (Code == null)
            {
                throw new ArgumentNullException(m_CodeName);
            }
            if (Address == null)
            {
                throw new ArgumentNullException(m_AddressName);
            }
            if (Forced == null)
            {
                throw new ArgumentNullException(m_ForcedName);
            }
            if (ForcedValue == null)
            {
                throw new ArgumentNullException(m_ForcedValueName);
            }
            if (SignalIn == null)
            {
                throw new ArgumentNullException(m_SignalInName);
            }
            if (OutputName == null)
            {
                throw new ArgumentNullException(m_OutputNameName);
            }
        }

        protected override NodeBase CopyWithNewChildren(ReadOnlyCollection<NodeBase> NewChildren)
        {
            return new NodeAnalogOutput(Fields, NewChildren);
        }
        #endregion

        #region " BUILDER(S) "

        private static NodeBase Resurrect(
            ReadOnlyDictionary<FieldIdentifier, FieldBase> Fields,
            ReadOnlyCollection<NodeBase> Children)
        {
            Dictionary<FieldIdentifier, FieldBase> mutableFields =
                new Dictionary<FieldIdentifier, FieldBase>();
            // Code and Address are mandatory
            mutableFields.Add(new FieldIdentifier(m_ForcedName),
                    new FieldBool(false));
            mutableFields.Add(new FieldIdentifier(m_ForcedValueName),
                    new FieldConstant(FieldDataType.DataTypeEnum.NUMBER, FieldDataType.DefaultValue(FieldDataType.DataTypeEnum.NUMBER)));
            //Add Fields here: mutableFields.Add(new FieldIdentifier(m_CodeName),
            //        new FieldSolutionName("A123"));

            ReadOnlyDictionary<FieldIdentifier, FieldBase> defaultFields =
                new ReadOnlyDictionary<FieldIdentifier, FieldBase>(mutableFields);
            return new NodeAnalogOutput(
                SetFieldDefaults(Fields, defaultFields), Children);
        }

        public static NodeAnalogOutput BuildWith(FieldIdentifier Code, FieldString Address, FieldSignalName OutputName)
        {
            //build fields
            Dictionary<FieldIdentifier, FieldBase> mutableFields =
                new Dictionary<FieldIdentifier, FieldBase>();
            mutableFields.Add(new FieldIdentifier(m_CodeName), Code);
            mutableFields.Add(new FieldIdentifier(m_AddressName), Address);
            mutableFields.Add(new FieldIdentifier(m_ForcedName), new FieldBool(false));
            mutableFields.Add(new FieldIdentifier(m_ForcedValueName), new FieldConstant(FieldDataType.DataTypeEnum.NUMBER, FieldDataType.DefaultValue(FieldDataType.DataTypeEnum.NUMBER)));
            mutableFields.Add(new FieldIdentifier(m_OutputNameName), OutputName);
            //Add Fields here: mutableFields.Add(new FieldIdentifier(m_CodeName), Code);

            //build children
            KeyedNodeCollection<NodeBase> mutableChildren =
                new KeyedNodeCollection<NodeBase>();
            mutableChildren.Add(NodeSignalIn.BuildWith(
                new FieldDataType(FieldDataType.DataTypeEnum.NUMBER),
                new FieldConstant(FieldDataType.DataTypeEnum.NUMBER, FieldDataType.DefaultValue(FieldDataType.DataTypeEnum.NUMBER))));
            //Add Children here: mutableChildren.Add(SomeChild);

            //build node
            NodeAnalogOutput Builder = new NodeAnalogOutput(
                new ReadOnlyDictionary<FieldIdentifier, FieldBase>(mutableFields),
                new ReadOnlyCollection<NodeBase>(mutableChildren));

            return Builder;
        }
        #endregion
    }
}
