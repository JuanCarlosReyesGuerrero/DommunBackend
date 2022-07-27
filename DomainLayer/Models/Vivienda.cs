﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public enum TiposVivienda
    {
        [Description("Apartamento")]
        Apartamento = 1,

        [Description("Casa")]
        Casa = 2,
    }

    public class Vivienda : BaseEntity
    {



        //    habitaciones = models.IntegerField(null=True, blank=True, verbose_name='Número de habitaciones',
        //                                   help_text='No Incluyen cuartos de servicio', default=0)
        public int Estudios { get; set; }
        //habitaciones_auxiliares = models.IntegerField(null=True, blank=True,
        //                                              verbose_name='Número de cuartos de servicio',
        //                                              help_text='', default=0)
        //banos = models.IntegerField(null=True, blank=True, verbose_name='Número de baños',
        //                            help_text='', default=0)
        //banos_sociales = models.IntegerField(null=True, blank=True, verbose_name='Número de baños sociales',
        //                                     help_text='', default=0)
        //banos_servicio = models.IntegerField(null=True, blank=True, verbose_name='Número de baños de servicio',
        //                                     help_text='', default=0)

        //anio_construccion = models.IntegerField(null=True, blank=True, verbose_name='Año de construcción',
        //                                        help_text='', default=0)

        //balcones = models.IntegerField(null=True, blank=True, verbose_name='Número de balcones', default=0)
        //terrazas = models.IntegerField(null=True, blank=True, verbose_name='Número de terrazas', default=0)

        //area_privada = models.DecimalField(null=True, blank=True, decimal_places=2, max_digits=8,
        //                                   verbose_name='Área privada')
        //area_construida = models.DecimalField(null=True, blank=True, decimal_places=2, max_digits=8,
        //                                      verbose_name='Área construida')
        //area_terraza = models.DecimalField(null=True, blank=True, decimal_places=2, max_digits=5,
        //                                   verbose_name='Área terraza')
        //area_lote = models.DecimalField(null=True, blank=True, decimal_places=2, max_digits=8, verbose_name='Área lote')

        //TIPO_ESTACIONAMIENTO_N_A = 0
        //TIPO_ESTACIONAMIENTO_EN_FILA = 1
        //TIPO_ESTACIONAMIENTO_INDEPENDIENTES = 2

        //TIPOS_ESTACIONAMIENTO = (
        //    (TIPO_ESTACIONAMIENTO_N_A, 'N/A'),
        //    (TIPO_ESTACIONAMIENTO_EN_FILA, 'En fila'),
        //    (TIPO_ESTACIONAMIENTO_INDEPENDIENTES, 'Independientes'),
        //)

        //tipo_estacionamientos = models.IntegerField(null=False, choices=TIPOS_ESTACIONAMIENTO,
        //                                            default=TIPO_ESTACIONAMIENTO_EN_FILA)

        //estacionamientos_cubiertos = models.IntegerField(null=True, blank=True, verbose_name='Número de garajes cubiertos',
        //                                                 default=0)
        //estacionamientos_descubiertos = models.IntegerField(null=True, blank=True,
        //                                                    verbose_name='Número de garajes descubiertos',
        //                                                    default=0)
        //estacionamientos_totales = models.IntegerField(null=True, blank=True,
        //                                               verbose_name='Número total de garajes',
        //                                               help_text='Cubiertos y descubiertos', default=0)

        //amoblado = models.BooleanField(null=False, default=False)
        //estrato = models.IntegerField(null=True, blank=True)
        //deposito = models.BooleanField(null=False, default=False)


        [EnumDataType(typeof(TiposVivienda)), Display(Name = "Tipo Vivienda")]
        public TiposVivienda TipoVivienda { get; set; }

        public int PropiedadId { get; set; }
        public virtual Propiedad? Propiedad { get; set; }

    }
}
