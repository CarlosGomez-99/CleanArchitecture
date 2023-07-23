﻿using StreamCasa.Interactors.Abstractions.DTO;
using StreamCasa.Interactors.Abstractions.Videos;

namespace StreamCasa.Presenters
{
    public class VideosPresenter : IAddVideosOutputPort
    {
        public VideosDTO Content { get; private set; }



        public Task Handle(VideosDTO ToAdd)
        {
            ToAdd.Description += " prueba de descripción";
            Content = ToAdd;
            return Task.CompletedTask;
        }
    }
}