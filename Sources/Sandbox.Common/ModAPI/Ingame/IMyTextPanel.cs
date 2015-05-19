using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandbox.ModAPI.Ingame
{
    /// <summary>
    /// LCD panel interface
    /// </summary>
    public interface IMyTextPanel : IMyFunctionalBlock, IMyPowerConsumerBlock
    {
        /// <summary>
        /// Public text writer
        /// </summary>
        /// <param name="value">text to display</param>
        /// <param name="append">true - append, false - overwrite (optional defaults to overwrite)</param>
        bool WritePublicText(string value, bool append = false);

        /// <summary>
        /// Public text reader
        /// </summary>
        string GetPublicText();

        /// <summary>
        /// Public title writer
        /// </summary>
        /// <param name="value">text to set</param>
        /// <param name="append">true - append, false - overwrite (optional defaults to overwrite)</param>
        bool WritePublicTitle(string value, bool append = false);

        /// <summary>
        /// Public title reader
        /// </summary>
        string GetPublicTitle();

        /// <summary>
        /// Private text writer
        /// </summary>
        /// <param name="value">text to display</param>
        /// <param name="append">true - append, false - overwrite (optional defaults to overwrite)</param>
        bool WritePrivateText(string value, bool append = false);

        /// <summary>
        /// Private text reader
        /// </summary>
        string GetPrivateText();

        /// <summary>
        /// Private title writer
        /// </summary>
        /// <param name="value">text to set</param>
        /// <param name="append">true - append, false - overwrite (optional defaults to overwrite)</param>
        bool WritePrivateTitle(string value, bool append = false);

        /// <summary>
        /// Public title reader
        /// </summary>
        string GetPrivateTitle();

        /// <summary>
        /// Add texture image to lcd by name
        /// </summary>
        void AddImageToSelection(string id, bool checkExistance = false);

        /// <summary>
        /// Add multiple texture images to lcd
        /// </summary>
        void AddImagesToSelection(List<string> ids, bool checkExistance = false);

        /// <summary>
        /// Remove texture image from lcd by name
        /// </summary>
        void RemoveImageFromSelection(string id, bool removeDuplicates = false);

        /// <summary>
        /// Remove multiple texture images from lcd
        /// </summary>
        void RemoveImagesFromSelection(List<string> ids, bool removeDuplicates = false);

        /// <summary>
        /// Clear image texture list
        /// </summary>
        void ClearImagesFromSelection();

        /// <summary>
        /// Instruct display to show public text value
        /// </summary>
        void ShowPublicTextOnScreen();

        /// <summary>
        /// Instruct display to show private text value
        /// </summary>
        void ShowPrivateTextOnScreen();

        /// <summary>
        /// Instruct display to show picture on screen
        /// </summary>
        void ShowTextureOnScreen();

        /// <summary>
        /// Instruct display to show private text, public text or nothing 
        /// </summary>
        void SetShowOnScreen(Sandbox.Common.ObjectBuilders.ShowTextOnScreenFlag set);
    }
}
