using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Poulina.GestionCommentaire.Data.Context;
using Poulina.GestionCommentaire.Data.Repository;
using Poulina.GestionCommentaire.Domain.Commandes;
using Poulina.GestionCommentaire.Domain.Handlers;
using Poulina.GestionCommentaire.Domain.Interfaces;
using Poulina.GestionCommentaire.Domain.Models;
using Poulina.GestionCommentaire.Domain.Queries;
using System;
using System.Collections.Generic;

namespace GestionCommentaire.Infra.Ioc
{
    public class DependencyContrainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<GestionCommContext>();




            //CatDemandeInfo
            services.AddScoped<IRepositoryGeneric<CatDemandeInfo>, RepositoryGeneric<CatDemandeInfo>>();

            services.AddScoped<IRequestHandler<GetAllQueryGeneric<CatDemandeInfo>, List<CatDemandeInfo>>, GetAllHandlerGeneric<CatDemandeInfo>>();
            services.AddScoped<IRequestHandler<GetIdQueryGeneric<CatDemandeInfo>, CatDemandeInfo>, GetIdHandlerGeneric<CatDemandeInfo>>();
            services.AddScoped<IRequestHandler<CreateCommandGeneric<CatDemandeInfo>, string>, CreateHandlerGeneric<CatDemandeInfo>>();
            services.AddScoped<IRequestHandler<DeleteCommandGeneric<CatDemandeInfo>, string>, DeleteHandlerGeneric<CatDemandeInfo>>();
            services.AddScoped<IRequestHandler<UpdateCommandGeneric<CatDemandeInfo>, string>, UpdateHandlerGeneric<CatDemandeInfo>>();
            //Categorie
            services.AddScoped<IRepositoryGeneric<Categorie>, RepositoryGeneric<Categorie>>();

            services.AddScoped<IRequestHandler<GetAllQueryGeneric<Categorie>, List<Categorie>>, GetAllHandlerGeneric<Categorie>>();
            services.AddScoped<IRequestHandler<GetIdQueryGeneric<Categorie>, Categorie>, GetIdHandlerGeneric<Categorie>>();
            services.AddScoped<IRequestHandler<CreateCommandGeneric<Categorie>, string>, CreateHandlerGeneric<Categorie>>();
            services.AddScoped<IRequestHandler<DeleteCommandGeneric<Categorie>, string>, DeleteHandlerGeneric<Categorie>>();
            services.AddScoped<IRequestHandler<UpdateCommandGeneric<Categorie>, string>, UpdateHandlerGeneric<Categorie>>();

            //CommVote
            services.AddScoped<IRepositoryGeneric<CommVote>, RepositoryGeneric<CommVote>>();

            services.AddScoped<IRequestHandler<GetAllQueryGeneric<CommVote>, List<CommVote>>, GetAllHandlerGeneric<CommVote>>();
            services.AddScoped<IRequestHandler<GetIdQueryGeneric<CommVote>, CommVote>, GetIdHandlerGeneric<CommVote>>();
            services.AddScoped<IRequestHandler<CreateCommandGeneric<CommVote>, string>, CreateHandlerGeneric<CommVote>>();
            services.AddScoped<IRequestHandler<DeleteCommandGeneric<CommVote>, string>, DeleteHandlerGeneric<CommVote>>();
            services.AddScoped<IRequestHandler<UpdateCommandGeneric<CommVote>, string>, UpdateHandlerGeneric<CommVote>>();
            //CommDemandeInfo
            services.AddScoped<IRepositoryGeneric<CommDemandeInfo>, RepositoryGeneric<CommDemandeInfo>>();

            services.AddScoped<IRequestHandler<GetAllQueryGeneric<CommDemandeInfo>, List<CommDemandeInfo>>, GetAllHandlerGeneric<CommDemandeInfo>>();
            services.AddScoped<IRequestHandler<GetIdQueryGeneric<CommDemandeInfo>, CommDemandeInfo>, GetIdHandlerGeneric<CommDemandeInfo>>();
            services.AddScoped<IRequestHandler<CreateCommandGeneric<CommDemandeInfo>, string>, CreateHandlerGeneric<CommDemandeInfo>>();
            services.AddScoped<IRequestHandler<DeleteCommandGeneric<CommDemandeInfo>, string>, DeleteHandlerGeneric<CommDemandeInfo>>();
            services.AddScoped<IRequestHandler<UpdateCommandGeneric<CommDemandeInfo>, string>, UpdateHandlerGeneric<CommDemandeInfo>>();
            //Commentaire
            services.AddScoped<IRepositoryGeneric<Commentaires>, RepositoryGeneric<Commentaires>>();

            services.AddScoped<IRequestHandler<GetAllQueryGeneric<Commentaires>, List<Commentaires>>, GetAllHandlerGeneric<Commentaires>>();
            services.AddScoped<IRequestHandler<GetIdQueryGeneric<Commentaires>, Commentaires>, GetIdHandlerGeneric<Commentaires>>();
            services.AddScoped<IRequestHandler<CreateCommandGeneric<Commentaires>, string>, CreateHandlerGeneric<Commentaires>>();
            services.AddScoped<IRequestHandler<DeleteCommandGeneric<Commentaires>, string>, DeleteHandlerGeneric<Commentaires>>();
            services.AddScoped<IRequestHandler<UpdateCommandGeneric<Commentaires>, string>, UpdateHandlerGeneric<Commentaires>>();
            //DemandeInformation
            services.AddScoped<IRepositoryGeneric<DemandeInformation>, RepositoryGeneric<DemandeInformation>>();

            services.AddScoped<IRequestHandler<GetAllQueryGeneric<DemandeInformation>, List<DemandeInformation>>, GetAllHandlerGeneric<DemandeInformation>>();
            services.AddScoped<IRequestHandler<GetIdQueryGeneric<DemandeInformation>, DemandeInformation>, GetIdHandlerGeneric<DemandeInformation>>();
            services.AddScoped<IRequestHandler<CreateCommandGeneric<DemandeInformation>, string>, CreateHandlerGeneric<DemandeInformation>>();
            services.AddScoped<IRequestHandler<DeleteCommandGeneric<DemandeInformation>, string>, DeleteHandlerGeneric<DemandeInformation>>();
            services.AddScoped<IRequestHandler<UpdateCommandGeneric<DemandeInformation>, string>, UpdateHandlerGeneric<DemandeInformation>>();
            //Vote
            services.AddScoped<IRepositoryGeneric<Vote>, RepositoryGeneric<Vote>>();

            services.AddScoped<IRequestHandler<GetAllQueryGeneric<Vote>, List<Vote>>, GetAllHandlerGeneric<Vote>>();
            services.AddScoped<IRequestHandler<GetIdQueryGeneric<Vote>, Vote>, GetIdHandlerGeneric<Vote>>();
            services.AddScoped<IRequestHandler<CreateCommandGeneric<Vote>, string>, CreateHandlerGeneric<Vote>>();
            services.AddScoped<IRequestHandler<DeleteCommandGeneric<Vote>, string>, DeleteHandlerGeneric<Vote>>();
            services.AddScoped<IRequestHandler<UpdateCommandGeneric<Vote>, string>, UpdateHandlerGeneric<Vote>>();
            //SousCategorie
            services.AddScoped<IRepositoryGeneric<SousCategorie>, RepositoryGeneric<SousCategorie>>();


            services.AddScoped<IRequestHandler<GetAllQueryGeneric<SousCategorie>, List<SousCategorie>>, GetAllHandlerGeneric<SousCategorie>>();
            services.AddScoped<IRequestHandler<GetIdQueryGeneric<SousCategorie>, SousCategorie>, GetIdHandlerGeneric<SousCategorie>>();
            services.AddScoped<IRequestHandler<CreateCommandGeneric<SousCategorie>, string>, CreateHandlerGeneric<SousCategorie>>();
            services.AddScoped<IRequestHandler<DeleteCommandGeneric<SousCategorie>, string>, DeleteHandlerGeneric<SousCategorie>>();
            services.AddScoped<IRequestHandler<UpdateCommandGeneric<SousCategorie>, string>, UpdateHandlerGeneric<SousCategorie>>();
            services.AddScoped<IRequestHandler<UpdateCommandGeneric<SousCategorie>, string>, UpdateHandlerGeneric<SousCategorie>>();
        }
    }
}
