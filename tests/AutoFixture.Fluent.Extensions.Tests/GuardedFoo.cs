﻿using Ardalis.GuardClauses;

namespace Fluent.Idioms.Tests
{
    internal class GuardedFoo
    {
        private string Bar { get; set; }

        public GuardedFoo(string bar)
        {
            Guard.Against.Null(bar, nameof(bar));

            Bar = bar;
        }

        public void SetBar(string newBar)
        {
            Guard.Against.Null(newBar, nameof(newBar));

            Bar = newBar;
        }
    }
}
