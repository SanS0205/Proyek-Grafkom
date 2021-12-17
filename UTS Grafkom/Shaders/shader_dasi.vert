﻿#version 330 core

layout(location = 0) in vec3 aPosition;

uniform mat4 transform;

void main(){
    gl_Position = vec4(aPosition, 2.1) * transform;
}

