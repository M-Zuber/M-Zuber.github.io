Title: Api wrapper template for Visual Studio. Part 1
Published: 7/27/2018
Tags: [visualstudio, open source]
---
# Part 1

## Background
While working a new project of mine, I needed to be pulling data from [libraries.io]().
Unfortunately, there was no C# client available so I decided to [nerd-snipe]() myself and write my own.
Since one of the things I excel at is [yak shaving](), I decided to create a generic template that can be used anytime someone would want to create a .NET wrapper over an api. 

## Getting started
Step one was to decide on the architecture. Due to my familiarity with [octokit.net]() - a project which allows you to consume the [GitHub api]() from .NET projects - and my liking of the architechture, I choose it as my base.
Starting with deleting anything that could for sure be cut out, I soon had a minimal set of files that could be used as a solid foundation towards achieving my goal.

In order to keep up the momentum, I decided to push my inital work up to GitHub ([MyrmidonOrg/ApiWrapperTemplate]()) and then continue on from there.

Additionally I have submitted it to the [.NET Summer Hackfest]() and hopefully will be able to find some other developers to share the project with.

There is a lot to be done going forwards, from making it into an actual Visual Studio template, to allowing full customization when the template is used (instead of the cut, copy, paste that needs to be done now)