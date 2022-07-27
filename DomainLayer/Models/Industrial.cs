using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models
{
    public enum TiposBodega
    {
        [Description("Bodega")]
        Bodega = 1,       
    }

    public class Industrial:BaseEntity
    {

       

        public int Espacios { get; set; }

        //banos = models.IntegerField(null=True, blank=True, verbose_name='Número de baños',
        //                            help_text='', default=0)

        //anio_construccion = models.IntegerField(null=True, blank=True, verbose_name='Año de construcción',
        //                                        help_text='', default=0)

        //area_privada = models.DecimalField(null=True, blank=True, decimal_places=2, max_digits=8,
        //                                   verbose_name='Área privada')
        //area_construida = models.DecimalField(null=True, blank=True, decimal_places=2, max_digits=8,
        //                                      verbose_name='Área construida')
        //area_lote = models.DecimalField(null=True, blank=True, decimal_places=2, max_digits=8, verbose_name='Área lote')

        [EnumDataType(typeof(TiposBodega)), Display(Name = "Tipo Bodega")]
        public TiposBodega TipoBodega { get; set; }

        public int PropiedadId { get; set; }
        public virtual Propiedad? Propiedad { get; set; }

    }
}
