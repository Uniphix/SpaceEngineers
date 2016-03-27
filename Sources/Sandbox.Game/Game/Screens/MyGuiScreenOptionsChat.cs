using Sandbox.Graphics.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRage.Utils;
using VRageMath;

namespace Sandbox.Game.Gui
{
    public class MyGuiScreenOptionsChat : MyGuiScreenBase
    {
        public MyGuiScreenOptionsChat()
            : base(new Vector2(0.5f, 0.5f), MyGuiConstants.SCREEN_BACKGROUND_COLOR, size: new Vector2(600f, 800f) / MyGuiConstants.GUI_OPTIMAL_SIZE)
        {
            EnabledBackgroundFade = true;

            AddCaption(MyCommonTexts.ScreenCaptionChatOptions);

            var topLeft = m_size.Value * -0.5f;
            var topCenter = m_size.Value * new Vector2(0f, -0.5f);
            var bottomCenter = m_size.Value * (MyPerGameSettings.VoiceChatEnabled ? new Vector2(0f, 0.7f) : new Vector2(0f, 0.6f));
            float startHeight = MyPerGameSettings.VoiceChatEnabled ? 150f : 170f;

            Vector2 controlsOriginLeft = topLeft + new Vector2(110f, startHeight) / MyGuiConstants.GUI_OPTIMAL_SIZE;
            Vector2 controlsOriginRight = topCenter + new Vector2(-25f, startHeight) / MyGuiConstants.GUI_OPTIMAL_SIZE;
            Vector2 controlsDelta = new Vector2(0f, 60f) / MyGuiConstants.GUI_OPTIMAL_SIZE;
            /*
            //  Chat color 1
            m_hueSlider1 = new MyGuiControlSlider(
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
            m_saturationSlider1 = new MyGuiControlSlider(
                position: new Vector2(x / 1600f, (y + 150) / 1200f),
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
            m_valueSlider1 = new MyGuiControlSlider(
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

            m_hueSlider1.ValueChanged += OnValueChange;
            m_saturationSlider1.ValueChanged += OnValueChange;
            m_valueSlider1.ValueChanged += OnValueChange;

            m_hueLabel1 = new MyGuiControlLabel(position: new Vector2(100 / 1600f, y / 1200f), text: String.Empty, originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER);
            m_saturationLabel1 = new MyGuiControlLabel(position: new Vector2(100 / 1600f, (y + 100) / 1200f), text: String.Empty, originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER);
            m_valueLabel1 = new MyGuiControlLabel(position: new Vector2(100 / 1600f, (y + 200) / 1200f), text: String.Empty, originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER);

            Controls.Add(new MyGuiControlLabel(position: new Vector2(x / 1600f, y / 1200f), text: "Hue:", originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER));
            Controls.Add(m_hueLabel1);
            Controls.Add(m_hueSlider1);
            Controls.Add(new MyGuiControlLabel(position: new Vector2(x / 1600f, (y + 100) / 1200f), text: "Saturation:", originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER));
            Controls.Add(m_saturationLabel1);
            Controls.Add(m_saturationSlider1);
            Controls.Add(new MyGuiControlLabel(position: new Vector2(x / 1600f, (y + 200) / 1200f), text: "Value:", originAlign: MyGuiDrawAlignEnum.HORISONTAL_LEFT_AND_VERTICAL_CENTER));
            Controls.Add(m_valueLabel1);
            Controls.Add(m_valueSlider1);
            m_ColorControlPanel1 = new MyGuiControlPanel(
                size: new Vector2(0.03f, 0.25f),
                position: new Vector2(((x + 25) / 1600f), (y + 300) / 1200f));
            m_ColorControlPanel1.ColorMask = Color.White;
            m_ColorControlPanel1.BackgroundTexture = MyGuiConstants.TEXTURE_GUI_BLANK;

            Controls.Add(m_ColorControlPanel1);
            Controls.Add(new MyGuiControlButton(
                size: new Vector2(100f, 0.1f),
                position: new Vector2(0 / 1600f, (y + 285 + 36) / 1200f),
                text: new StringBuilder("Reset"),
                onButtonClick: OnDefaultsClick));
            Controls.Add(new MyGuiControlButton(
                size: new Vector2(100f, 0.1f),
                position: new Vector2(0 / 1600f, (y + 360 + 36) / 1200f),
                text: new StringBuilder("OK"),
                onButtonClick: OnOkClick));
            Controls.Add(new MyGuiControlButton(
                position: new Vector2(0 / 1600f, (y + 435 + 36) / 1200f),
                text: new StringBuilder("Cancel"),
                onButtonClick: OnCancelClick));

            //  Update controls with values from config file
            UpdateFromConfig(m_settingsOld);
            UpdateFromConfig(m_settingsNew);
            UpdateControls(m_settingsOld);
            */

            CloseButtonEnabled = true;
            CloseButtonOffset = MakeXAndYEqual(new Vector2(-0.006f, 0.006f));
        }

        public override string GetFriendlyName()
        {
            return "Screen options Chat";
        }
    }
}
