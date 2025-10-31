Stringer - dotnet starter kit
=========================
[![Build Status](https://github.com/0xor1/stringer/actions/workflows/build.yml/badge.svg)](https://github.com/0xor1/stringer/actions/workflows/build.yml)
[![Coverage Status](https://coveralls.io/repos/github/0xor1/stringer/badge.svg)](https://coveralls.io/github/0xor1/stringer)
[![Demo Live](https://img.shields.io/badge/demo-live-4ec820)](https://stringer.dans-demos.com)

This project is the basic starting point for my dotnet based projects, 
revolving around the primary technologies:

* Client - Blazor WASM
* Server - Aspnet core with RPC pattern
* DB - Ef core

### Prerequisites

To build and run this project you need `.net core 8`, `docker` and `docker-compose` installed.

To build and run unit tests:
```bash
./bin/pre
```
To build and run the app:
```bash
./bin/run
```
You can pass parameter `nuke` to either `./bin/pre` or `./bin/run` to delete
docker containers and rebuild them, this is typically useful if there has been a db schema change.