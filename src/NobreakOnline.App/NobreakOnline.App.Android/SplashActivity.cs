﻿using Android.App;
using Android.OS;

namespace NobreakOnline.App.Droid
{
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Threading.Thread.Sleep(3000);
            StartActivity(typeof(MainActivity));
        }
    }
}