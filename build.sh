#!/bin/bash

#build Vote.Cast
(cd src ; cd cast ; dotnet build -c Release )

#build Dockerfiles
docker-compose build