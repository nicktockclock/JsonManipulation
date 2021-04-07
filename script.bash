#!/bin/bash
for file in json_data/*
do
    dotnet Publish/JsonManipulation.dll "$file"
done