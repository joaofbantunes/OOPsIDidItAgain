# OOPs, I did it again (aka Untangling the mess we're making out of OOP)

This repository contains the demo code and slides for my presentation titled "OOPs, I did it again" (aka "Untangling the mess we're making out of OOP").

Feel free to use the issues to ask questions (or suggest improvements). For other ways of contact, you can check out my website at [https://antunes.dev](https://antunes.dev).

## Abstract

Object oriented is one of the most broadly used programming paradigms. Problem is, most of the times, even if we use a primarily OO programming language, we're not really taking advantage of it or other useful paradigms and language features, ending up in a mostly procedural scenario.

In this session, I’d like to share some ideas to improve our code, making it easier to understand and maintain, taking better advantage of our languages’ capabilities, mixing paradigms as appropriate.

None of these ideas are new, but it seems we keep forgetting them and get back to the same old mess.

## About the demo code

All the demo projects compile, but only the 6th project is configured enough to run and handle a request.

The idea of having it running is just to be able to see the discussed request in action, particularly so that anyone interested can have some pointers on how to implement some of the infrastructural things needed to have everything working together (e.g. model binding or JSON converters).

**NOTE:** it should go without saying that this code, particularly infrastructure bits, is not production ready. The goal was to have code that would be able to illustrate some ideas. There are more steps to take to get it to production levels.
