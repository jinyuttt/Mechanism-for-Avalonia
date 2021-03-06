﻿using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mechanism.AvaloniaUI.Controls.ToolStrip
{
    public class MoveOrRemoveFromToolStripBehavior : Behavior<Thumb>
    {
        public static readonly StyledProperty<ToolStrip> OwnerProperty =
            AvaloniaProperty.Register<MoveOrRemoveFromToolStripBehavior, ToolStrip>(nameof(Owner));

        public ToolStrip Owner
        {
            get => GetValue(OwnerProperty);
            set => SetValue(OwnerProperty, value);
        }

        /*public static readonly StyledProperty<IToolStripItem> TargetItemProperty =
            AvaloniaProperty.Register<MoveOrRemoveFromToolStripBehavior, IToolStripItem>(nameof(TargetItem));

        public IToolStripItem TargetItem
        {
            get => GetValue(TargetItemProperty);
            set => SetValue(TargetItemProperty, value);
        }*/
        public static readonly StyledProperty<ToolStripItemReference> TargetProperty =
            AvaloniaProperty.Register<ToolStripItemPointerOverBehavior, ToolStripItemReference>(nameof(Target));

        public ToolStripItemReference Target
        {
            get => GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            Debug.WriteLine("MoveOrRemoveFromToolStripBehavior");
            AssociatedObject.DragCompleted += AssociatedObject_DragCompleted;
        }

        private void AssociatedObject_DragCompleted(object sender, Avalonia.Input.VectorEventArgs e)
        {
            Debug.WriteLine("Drag completed");
            Owner.ValidateMoveOrRemoveFromToolStrip(Target);
        }
    }
}
