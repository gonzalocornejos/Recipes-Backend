﻿namespace recipes_backend.Services.Interfaces
{
    public interface IMailingService
    {
        Task EnviarCodigoValidacion(string emailDestino, int codigoValidacion);

        Task EnviarMaildeActivacion(string emailDestino, string nickName);
    }
}
