﻿using System;
using System.Collections.Generic;

namespace KPreisser.UI
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TaskDialogCommonButton : TaskDialogButton
    {
        private TaskDialogResult result;

        private bool visible = true;


        /// <summary>
        /// 
        /// </summary>
        public TaskDialogCommonButton()
            : base()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="button"></param>
        public TaskDialogCommonButton(
                TaskDialogResult button)
            : base()
        {
            if (!IsValidCommonButton(button))
                throw new ArgumentException();

            this.result = button;
        }


        /// <summary>
        /// 
        /// </summary>
        public TaskDialogResult Result
        {
            get => this.result;

            set
            {
                this.boundTaskDialogContents?.DenyIfBound();

                if (!IsValidCommonButton(value))
                    throw new ArgumentException();

                // If we are part of a CommonButtonCollection, we must now notify it
                // that we changed our result.
                (this.Collection as TaskDialogCommonButtonCollection)?.HandleKeyChange(
                        this,
                        value);

                // If this was successful or we are not part of a collection,
                // we can now set the result.
                this.result = value;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates if this <see cref="TaskDialogCommonButton"/>
        /// should be shown when displaying the Task Dialog.
        /// </summary>
        /// <remarks>
        /// Setting this to <c>false</c> allows you to still receive the
        /// <see cref="TaskDialogButton.ButtonClicked"/> event (e.g. for the
        /// <see cref="TaskDialogResult.Cancel"/> button when
        /// <see cref="TaskDialogContents.AllowCancel"/> is set), or to call the
        /// <see cref="TaskDialogButton.Click"/> method even if the button is not
        /// shown.
        /// </remarks>
        public bool Visible
        {
            get => this.visible;

            set
            {
                this.boundTaskDialogContents?.DenyIfBound();

                this.visible = value;
            }
        }


        private static bool IsValidCommonButton(
                TaskDialogResult button)
        {
            return button > 0 &&
                    button <= TaskDialogResult.Continue;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.result.ToString();
        }


        internal override TaskDialogFlags GetFlags()
        {
            if (this.visible)
                return base.GetFlags();
            else
                return default;
        }

        internal override void ApplyInitialization()
        {
            if (this.visible)
                base.ApplyInitialization();
        }


        private protected override int GetButtonID()
        {
            return (int)this.result;
        }

        private protected override bool CanUpdate()
        {
            return this.visible;
        }
    }
}
