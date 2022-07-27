using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public enum TiposComercial
    {
        [Description("Local")]
        Local = 1,

        [Description("Oficinas")]
        Oficinas = 2,
    }

    public class Comercial:BaseEntity
    {
     
   

   public int Espacios { get; set; }

        //cocineta = models.BooleanField(null=False, default=False)

        //banos = models.IntegerField(null=True, blank=True, verbose_name='Número de baños',
        //                            help_text='', default=0)

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



        [EnumDataType(typeof(TiposComercial)), Display(Name = "Tipo Comercial")]
        public TiposComercial TipoComercial { get; set; }

        public int PropiedadId { get; set; }
        public virtual Propiedad? Propiedad { get; set; }
    }
}
