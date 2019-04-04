// ***********************************************************************
// Assembly         : Zeroit.Framework.Form
// Author           : ZEROIT
// Created          : 11-24-2018
//
// Last Modified By : ZEROIT
// Last Modified On : 12-15-2018
// ***********************************************************************
// <copyright file="Animation.cs" company="Zeroit Dev Technologies">
//     Copyright © Zeroit Dev Technologies  2017. All Rights Reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Zeroit.Framework.Form.ModernForm.Utils
{
    /// <summary>
    /// Class Animation.
    /// </summary>
    public class Animation
    {
        /// <summary>
        /// The base timer
        /// </summary>
        readonly Timer baseTimer;
        /// <summary>
        /// The global cancel
        /// </summary>
        static List<String> globalCancel = new List<String>();
        /// <summary>
        /// The end anim
        /// </summary>
        Action<Animation> endAnim;
        /// <summary>
        /// The has been canceled
        /// </summary>
        bool hasBeenCanceled;
        /// <summary>
        /// The identifier
        /// </summary>
        string identifier = "unknown";

        /// <summary>
        /// Class AnimationBuilder.
        /// </summary>
        public class AnimationBuilder
        {
            /// <summary>
            /// The count
            /// </summary>
            int count = 0;
            /// <summary>
            /// The count limit
            /// </summary>
            int countLimit = -1;
            /// <summary>
            /// The multiplier
            /// </summary>
            int multiplier = 1;
            /// <summary>
            /// The interval
            /// </summary>
            int interval = 1;
            /// <summary>
            /// The identifier
            /// </summary>
            String identifier = "unknown";
            /// <summary>
            /// The action
            /// </summary>
            Action<Animation> action;

            /// <summary>
            /// Withes the action.
            /// </summary>
            /// <param name="a">a.</param>
            /// <returns>AnimationBuilder.</returns>
            public AnimationBuilder WithAction(Action<Animation> a)
            {
                action = a;
                return this;
            }

            /// <summary>
            /// Withes the count limit.
            /// </summary>
            /// <param name="a">a.</param>
            /// <returns>AnimationBuilder.</returns>
            public AnimationBuilder WithCountLimit(int a)
            {
                var clone = (Action<Animation>)action.Clone();
                countLimit = a;
                action = new Action<Animation>((aa) => {
                    if (count < countLimit) {
                        clone.Invoke(aa);
                        count++;
                    } else
                        aa.Cancel();
                });
                return this;
            }

            /// <summary>
            /// Withes the identifier.
            /// </summary>
            /// <param name="a">a.</param>
            /// <returns>AnimationBuilder.</returns>
            public AnimationBuilder WithIdentifier(String a)
            {
                identifier = a;
                return this;
            }
            /// <summary>
            /// Withes the interval.
            /// </summary>
            /// <param name="a">a.</param>
            /// <returns>AnimationBuilder.</returns>
            public AnimationBuilder WithInterval(int a)
            {
                interval = a;
                return this;
            }

            /// <summary>
            /// Withes the multiplier.
            /// </summary>
            /// <param name="a">a.</param>
            /// <returns>AnimationBuilder.</returns>
            public AnimationBuilder WithMultiplier(int a)
            {
                multiplier = a;
                return this;
            }

            /// <summary>
            /// Builds this instance.
            /// </summary>
            /// <returns>Animation.</returns>
            public Animation Build()
            {
                return new Animation(action, identifier, interval, multiplier);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Animation"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="globalIdentifier">The global identifier.</param>
        /// <param name="interval">The interval.</param>
        /// <param name="multiplier">The multiplier.</param>
        Animation(Action<Animation> action, String globalIdentifier = "unknown", int interval = 1, int multiplier = 1)
        {
            identifier = globalIdentifier;
            baseTimer = new Timer
            {
                Interval = interval
            };
            for (int i = 0; i < multiplier; i++) {
                baseTimer.Tick += (sender, e) => action?.Invoke(this);
            }
        }



        /// <summary>
        /// Starts this instance.
        /// </summary>
        /// <returns>Animation.</returns>
        public Animation Start()
        {
            if (!globalCancel.Contains(identifier)) {
                baseTimer.Start();
                if (identifier != "unknown")
                    globalCancel.Add(identifier);
            }
            return this;
        }

        /// <summary>
        /// Cancels this instance.
        /// </summary>
        /// <returns>Animation.</returns>
        public Animation Cancel()
        {
            baseTimer.Stop();
            if (identifier != "unknown" && globalCancel.Contains(identifier))
                globalCancel.Remove(identifier);
            if (endAnim != null && (!hasBeenCanceled))
                endAnim(this);
            hasBeenCanceled = true;
            return this;
        }

        /// <summary>
        /// Ends the specified end.
        /// </summary>
        /// <param name="end">The end.</param>
        /// <returns>Animation.</returns>
        public Animation End(Action<Animation> end)
        {
            endAnim = end;
            return this;
        }
    }
}
