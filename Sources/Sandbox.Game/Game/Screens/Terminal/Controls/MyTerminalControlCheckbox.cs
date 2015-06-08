using Sandbox.Game.Entities.Cube;
using Sandbox.Graphics.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sandbox.Game.World;
using Sandbox.Game.Screens.Terminal.Controls;
using VRage.Utils;
using Sandbox.Game.Localization;
using VRage;
using VRage.Library.Utils;
using VRageMath;

namespace Sandbox.Game.Gui
{
    public class MyTerminalControlCheckbox<TBlock> : MyTerminalValueControl<TBlock, bool>
        where TBlock : MyTerminalBlock
    {
        Action<TBlock> m_action;

        public Func<TBlock, bool> Getter;
        public Action<TBlock, bool> Setter;

        private MyGuiControlCheckbox m_checkbox;
        private Action<MyGuiControlCheckbox> m_checkboxClicked;

        public readonly MyStringId Title;
        public readonly MyStringId OnText;
        public readonly MyStringId OffText;
        public readonly MyStringId Tooltip;

        public MyTerminalControlCheckbox(string id, MyStringId title, MyStringId tooltip, MyStringId? on = null, MyStringId? off = null)
            : base(id)
        {
            Title = title;
            OnText = on ?? MySpaceTexts.SwitchText_On;
            OffText = off ?? MySpaceTexts.SwitchText_Off;
            Tooltip = tooltip;
        }

        protected override MyGuiControlBase CreateGui()
        {
            m_checkbox = new MyGuiControlCheckbox(toolTip: MyTexts.GetString(Tooltip) + " - " + (FirstBlock != null ?  (Getter(FirstBlock) ? OnText : OffText) : OffText), visualStyle: Common.ObjectBuilders.Gui.MyGuiControlCheckboxStyleEnum.SliderOnOff, originAlign: MyGuiDrawAlignEnum.HORISONTAL_RIGHT_AND_VERTICAL_CENTER);
//            m_checkbox.Size = new Vector2(PREFERRED_CONTROL_WIDTH, m_checkbox.Size.Y);
            m_checkboxClicked = OnCheckboxClicked;
            m_checkbox.IsCheckedChanged = m_checkboxClicked;            

            MyGuiControlBase control = new MyGuiControlBlockProperty(MyTexts.GetString(Title), MyTexts.GetString(Tooltip), m_checkbox, MyGuiControlBlockPropertyLayoutEnum.Horizontal, false);
            control.Size = new Vector2(PREFERRED_CONTROL_WIDTH, control.Size.Y);

            return control;
        }

        void OnCheckboxClicked(MyGuiControlCheckbox obj)
        {
            foreach (var item in TargetBlocks)
            {
                Setter(item, obj.IsChecked);
            }
        }

        protected override void OnUpdateVisual()
        {
            var first = FirstBlock;
            if (first != null)
            {
                m_checkbox.IsCheckedChanged -= m_checkboxClicked;
                m_checkbox.IsChecked = Getter(first);
                m_checkbox.IsCheckedChanged += m_checkboxClicked;
                m_checkbox.SetToolTip(MyTexts.GetString(Tooltip) + " - " + MyTexts.GetString(m_checkbox.IsChecked ? OnText : OffText));
            }
            base.OnUpdateVisual();
        }

        void SwitchAction(TBlock block)
        {
            Setter(block, !Getter(block));
        }

        void CheckAction(TBlock block)
        {
            Setter(block, true);
        }

        void UncheckAction(TBlock block)
        {
            Setter(block, false);
        }

        void Writer(TBlock block, StringBuilder result, StringBuilder onText, StringBuilder offText)
        {
            result.Append(Getter(block) ? onText : offText);
        }

        void AppendAction(MyTerminalAction<TBlock> action)
        {
            var arr = Actions ?? new MyTerminalAction<TBlock>[0];
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = action;
            Actions = arr;
        }

        public MyTerminalAction<TBlock> EnableToggleAction(string icon, StringBuilder name, StringBuilder onText, StringBuilder offText)
        {
            var action = new MyTerminalAction<TBlock>(Id, name, SwitchAction, (x, r) => Writer(x, r, onText, offText), icon);
            AppendAction(action);

            return action;
        }

        public MyTerminalAction<TBlock> EnableOnAction(string icon, StringBuilder name, StringBuilder onText, StringBuilder offText)
        {
            var action = new MyTerminalAction<TBlock>(Id + "_On", name, CheckAction, (x, r) => Writer(x, r, onText, offText), icon);
            AppendAction(action);

            return action;
        }

        public MyTerminalAction<TBlock> EnableOffAction(string icon, StringBuilder name, StringBuilder onText, StringBuilder offText)
        {
            var action = new MyTerminalAction<TBlock>(Id + "_Off", name, UncheckAction, (x, r) => Writer(x, r, onText, offText), icon);
            AppendAction(action);

            return action;
        }

        public override bool GetValue(TBlock block)
        {
            return Getter(block);
        }

        public override void SetValue(TBlock block, bool value)
        {
            Setter(block, value);
        }

        public override bool GetDefaultValue(TBlock block)
        {
            return false;
        }

        public override bool GetMininum(TBlock block)
        {
            return false;
        }

        public override bool GetMaximum(TBlock block)
        {
            return true;
        }
    }
}
