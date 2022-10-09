using System;
using Android.Animation;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Support.V7.App;
using Android.Views.Animations;

namespace Vertical.ProgressBar
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Android.Widget.ProgressBar _progressBar;
        private Button _addButton;
        private Button _subtractButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            _progressBar = FindViewById<Android.Widget.ProgressBar>(Resource.Id.progressbar_current_order) ?? throw new NullReferenceException();
            _addButton = FindViewById<Button>(Resource.Id.button_add) ?? throw new NullReferenceException();
            _subtractButton = FindViewById<Button>(Resource.Id.button_subtract) ?? throw new NullReferenceException();

            _addButton.Click += (sender, args) =>
            {
                AnimateProgressBar(newValue: _progressBar.Progress + 10, animationDurationInMs: 250);
            };
            
            _subtractButton.Click += (sender, args) =>
            {
                AnimateProgressBar(newValue: _progressBar.Progress + -10, animationDurationInMs: 250);
            };
        }

        private void AnimateProgressBar(int newValue, int animationDurationInMs)
        {
            var animator = ValueAnimator.OfInt(_progressBar.Progress, newValue);
            animator.SetDuration(animationDurationInMs);
            animator.SetInterpolator(new DecelerateInterpolator());
            animator.Update += (sender, args) =>
            {
                _progressBar.Progress = (int)args.Animation.AnimatedValue;
            };
            animator.Start();
        }
    }
}