
using Sandbox.Game.Entities;
using Sandbox.Game.GUI;
using Sandbox.Game.Multiplayer;
using Sandbox.Game.Screens.Helpers;
using Sandbox.Game.World;
using Sandbox.Graphics.GUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using VRage;
using VRage.Input;
using VRage.Utils;
using VRageMath;

namespace Sandbox.Game.Gui
{
    class MyGuiScreenSimpleColorPicker : MyGuiScreenBase
    {

        private MyGuiControlSlider m_hueSlider;
        private MyGuiControlSlider m_saturationSlider;
        private MyGuiControlSlider m_valueSlider;
        private MyGuiControlLabel m_hueLabel;
        private MyGuiControlLabel m_saturationLabel;
        private MyGuiControlLabel m_valueLabel;
        private const int x = -170;
        private const int y = -250;
        //private const int defColLine = 300;
        //private const int defColCol = 25;
        private Color m_InitialColor; // initial color as RGB
        private Vector3 m_SelectedColor; // selected color as HSV
        private MyGuiControlPanel m_ColorControlPanel;

        private const string m_hueScaleTexture = "Textures\\GUI\\HueScale.png";

        public MyGuiScreenSimpleColorPicker(Color InitialColor)
            : base(GetInitPosition(), MyGuiConstants.SCREEN_BACKGROUND_COLOR, new Vector2(400f / 1600f, 700 / 1200f))
        {
            CanHideOthers = false;
            RecreateControls(true);
            m_InitialColor = InitialColor;
            m_SelectedColor = InitialColor.ColorToHSV();
			UpdateSliders(m_SelectedColor);
            UpdateLabels();
        }

        private static Vector2 GetInitPosition()
        {
            if ((float)MySandboxGame.ScreenSize.X / MySandboxGame.ScreenSize.Y < 1.5f)
                return new Vector2(0.15f, 0.3f);
            else
                return new Vector2(0.06f, 0.3f);
        }

        public override void RecreateControls(bool constructor)
        {
            base.RecreateControls(constructor);

            AddCaption("Simple color picker");

            m_hueSlider = new MyGuiControlSlider(
                position: new Vector2(x / 1600f, (y + 50) / 1200f),
                width: 0.25f,
                minValue: 0,
                maxValue: 360,
                labelText: String.Empty,
                labelDecimalPlaces: 0,
                labelSpaceWidth: 50 / 1200f,
                intValue: true,
                originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER,
                visualStyle: MyGuiControlSliderStyleEnum.Hue
                );
            m_saturationSlider  = new MyGuiControlSlider(
                position: new Vector2(x / 1600f, (y + 150) / 1200f),
                width: 0.25f,
                minValue: -100,
                maxValue: 100,
                defaultValue: 0,
                labelText: String.Empty,
                labelDecimalPlaces: 0,
                labelSpaceWidth: 50/1200f,
                intValue: true,
                originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER
                );
            m_valueSlider = new MyGuiControlSlider(
                position: new Vector2(x / 1600f, (y + 250) / 1200f),
                width: 0.25f,
                minValue: -100,
                maxValue: 100,
                defaultValue: 0,
                labelText: String.Empty,
                labelDecimalPlaces: 0,
                labelSpaceWidth: 50 / 1200f,
                intValue: true,
                originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER
                );

            m_hueSlider.ValueChanged += OnValueChange;
            m_saturationSlider.ValueChanged += OnValueChange;
            m_valueSlider.ValueChanged += OnValueChange;

            m_hueLabel = new MyGuiControlLabel(position: new Vector2(100 / 1600f, y / 1200f), text: String.Empty, originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER);
            m_saturationLabel = new MyGuiControlLabel(position: new Vector2(100 / 1600f, (y + 100) / 1200f), text: String.Empty, originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER);
            m_valueLabel = new MyGuiControlLabel(position: new Vector2(100 / 1600f, (y + 200) / 1200f), text: String.Empty, originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER);
            
            Controls.Add(new MyGuiControlLabel(position: new Vector2(x / 1600f, y / 1200f), text: "Hue:", originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER));
            Controls.Add(m_hueLabel);
            Controls.Add(m_hueSlider);
            Controls.Add(new MyGuiControlLabel(position: new Vector2(x / 1600f, (y + 100) / 1200f), text: "Saturation:", originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER));
            Controls.Add(m_saturationLabel);
            Controls.Add(m_saturationSlider);
            Controls.Add(new MyGuiControlLabel(position: new Vector2(x / 1600f, (y + 200) / 1200f), text: "Value:", originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER));
            Controls.Add(m_valueLabel);
            Controls.Add(m_valueSlider);
            Controls.Add(new MyGuiControlButton(
                size: new Vector2(100f, 0.1f),
				position: new Vector2(0 / 1600f, (y + 285 + 36) / 1200f),
                text: new StringBuilder("Reset"),
                onButtonClick: OnDefaultsClick));
            Controls.Add(new MyGuiControlButton(
                size: new Vector2 (100f,0.1f),
				position: new Vector2(0 / 1600f, (y + 360 + 36) / 1200f),
                text: new StringBuilder("OK"),
                onButtonClick: OnOkClick));
            Controls.Add(new MyGuiControlButton(
				position: new Vector2(0 / 1600f, (y + 435 + 36) / 1200f),
                text: new StringBuilder("Cancel"),
                onButtonClick: OnCancelClick));
            
            m_ColorControlPanel = new MyGuiControlPanel(
                size: new Vector2(0.03f, 0.25f),
				position: new Vector2(((x + 25) / 1600f), (y + 300) / 1200f));
            m_ColorControlPanel.ColorMask = m_InitialColor.ToVector4();
            m_ColorControlPanel.BackgroundTexture = MyGuiConstants.TEXTURE_GUI_BLANK;
            Controls.Add(m_ColorControlPanel);
        }

        protected override void OnShow()
        {
            base.OnShow();
        }

        protected override void OnClosed()
        {
            base.OnClosed();
        }

        protected override void OnHide()
        {
            base.OnHide();
        }

        protected void UpdateLabels()
        {
            m_hueLabel.Text = m_hueSlider.Value.ToString() + "°";
            m_saturationLabel.Text = m_saturationSlider.Value.ToString();
            m_valueLabel.Text = m_valueSlider.Value.ToString();
        }

        protected void UpdateSliders(Vector3 HSV)
        {
            m_hueSlider.Value = HSV.X * 360;
            m_saturationSlider.Value = HSV.Y * 100;
            m_valueSlider.Value = HSV.Z * 100;
        }

        public override void HandleInput(bool receivedFocusInThisUpdate)
        {
            base.HandleInput(receivedFocusInThisUpdate);
        } 

        private void OnValueChange(MyGuiControlSlider sender)
        {
            UpdateLabels();
            m_SelectedColor.X = (m_hueSlider.Value / 360f);
            m_SelectedColor.Y = (m_saturationSlider.Value / 100f);
            m_SelectedColor.Z = (m_valueSlider.Value / 100f);
            m_ColorControlPanel.ColorMask = m_SelectedColor.HSVtoColor().ToVector4();
        }

        private void OnDefaultsClick(MyGuiControlButton sender)
        {
            UpdateSliders(m_InitialColor);
        }

        private void OnOkClick(MyGuiControlButton sender)
        {
            this.CloseScreenNow();
        }

        private void OnCancelClick(MyGuiControlButton sender)
        {
            this.CloseScreenNow();
        }

        public override string GetFriendlyName()
        {
            return "ColorPickSimple";
        }

        public Color GetSelectedColor()
        {
            return m_SelectedColor.HSVtoColor();
        }
    }
}
