Title: Api wrapper template for Visual Studio
Tags: [visualstudio, open source]
---
While working a new project of mine, I needed to be pulling data from [libraries.io]().
Unfortunately, there was no `C#` client available so I decided to embark on the journey of creating my own.

Since one of the things I excel at is [nerd-sniping]() myself, I decided to create a generic template that can be used anytime someone would want to create a `.NET` wrapper over an api. 

Step one was to decide on the architecture. Thankfully there is a wonderful project out there - [octokit.net]() which allows you to consume the [GitHub api]() from `.NET` projects.
Taking that as my base, I started trimming out anything that was not needed, knowing that this would be the first of many passes before there was something that I could publish