﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.core
{
    class JSonStrings
    {
        public string JSonString { get; set; }

        public JSonStrings()
        {
            JSonString = @"{
  'Place': {
    'Address': 'Calle 41 # 55 - 80',
    'City': 'Medellin',
    'Country': 'Colombia',
    'Neighborhood': 'Plaza',
    'Capacity': 10000,
    'Location': {
      'Longitude': -75.57614,
      'Latitude': 6.24347
    },
    'Name': 'Pabellon Plaza Mayor Medellin',
    'Picture': {
      'ImagePath': 'PlaceImages/1',
      'Title': 'Foto Plaza Mayor Medellin',
      'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
      'ImageId': 1
    },
    'PlaceId': 1
  },
  'EventInformation': {
    'MainImage': {
      'ImagePath': 'EventImage/1',
      'Title': 'Foto General del Evento',
      'Description': 'Fotografía del evento',
      'ImageId': 2
    },
    'EventSocialNetworks': [
      {
        'Link': 'https://es-la.facebook.com/inexmoda/',
        'NetworkName': 'Facebook'
      },
      {
        'Link': 'https://twitter.com/inexmoda?lang=es',
        'NetworkName': 'Twitter'
      },
      {
        'Link': 'https://www.instagram.com/inexmoda/',
        'NetworkName': 'Instagram'
      }
    ],
    'EventDescription': 'ColombiaModa es un evento donde diseñadores de renombre muestran sus marcas y nuevas colecciones, es un evento para los amantes de la moda, ¡Disfruta de esta edición 2016 con nuevas tendencias para presentarte! ',
    'EventName': 'ColombiaModa'
  },
  'Presenters': [
    {
      'PresenterId': 1,
      'Name': 'Sueli Pereira',
      'Profile': 'Gerente de Comunicación y Moda de Santista Jeanswear',
      'Country': 'Brasil',
      'Photo': {
        'ImagePath': 'PresentersImages/1',
        'Title': 'Fotografía Sueli Pereira',
        'Description': 'Fotografía Sueli Pereira',
        'ImageId': 3
      },
      'PreviousWorks': [
        {
          'Title': 'Innovation & Design Global Manager',
          'Abstract': 'Experiencia como Manager de innovación y diseño global en Tavex Brasil S.A, continúa hasta el momento',
          'Year': '1999',
          'Picture': {
            'ImagePath': 'WorkImages/1',
            'Title': 'Tavex Brasil',
            'Description': 'Fotografía de la empresa',
            'ImageId': 4
          },
          'WorkId': 1,
          'ShortDescription': 'Experiencia en Tavex Brasil S.A'
        },
        {
          'Title': 'Journalist contributor to world fashion magazine',
          'Abstract': 'Experiencia como periodista asociada a la revista world fashion magazine en Tavex Brasil, continúa hasta el momento',
          'Year': '1999',
          'Picture': {
            'ImagePath': 'WorkImages/2',
            'Title': 'Tavex Brasil',
            'Description': 'Fotografía de la empresa',
            'ImageId': 5
          },
          'WorkId': 2,
          'ShortDescription': 'Experiencia en Tavex Brasil S.A'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 9,
            'Minutes': 0,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 26,
            'Year': 2016
          },
          'ConferenceId': 1,
          'Title': 'Tendencias Denim Invierno 2017',
          'Abstract': 'Esta charla tendrá tres macro temas de comportamiento, artes, culturas y direccionamientos para que las marcas comprendan qué caminos seguir para su colección de la temporada Invierno 2017. Direcciones de lavados y todos los contenidos con enfoque en Denim.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/1',
            'Title': 'Foto Tendencias Denim Invierno 2017',
            'Description': 'Fotografía del trabajo de conferencia presentado por Sueli Pereira',
            'ImageId': 6
          },
          'WorkId': 3,
          'ShortDescription': 'Nueva colección de invierno para Denim, conoce su inspiración artística y cultural'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://br.linkedin.com/in/sueli-pereira-37330216',
          'NetworkName': 'LinkedIn'
        }
      ]
    },
    {
     'PresenterId': 2,
       'Name': 'Pepa Pombo y Mónica Holguín',
      'Profile': 'Diseñadoras de Moda',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/2',
        'Title': 'Fotografía Pepa Pombo y Mónica Holguin',
        'Description': 'Fotografía Pepa Pombo y Mónica Holguin',
        'ImageId': 7
      },
      'PreviousWorks': [
        {
          'Title': 'Pepa Pombo (tienda)',
          'Abstract': 'Pepa Pombo es una marca colombiana especializada en tejido de punto y la define su herencia única. Se fundó en 1978 por la diseñadora Pepa Pombo y evolucionó a un negocio de familia. En los años 80 Pepa se convirtió en uno de los nombres renombrados de moda tanto en Colombia como en México. ',
          'Year': '1978',
          'Picture': {
            'ImagePath': 'WorkImages/3',
            'Title': 'Tienda Pepa Pombo',
            'Description': 'Fotografía de la empresa',
            'ImageId': 8
          },
          'WorkId': 4,
          'ShortDescription': 'Tienda de ropa, negocio familiar '
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 10,
            'Minutes': 30,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 26,
            'Year': 2016
          },
          'ConferenceId': 2,
          'Title': 'Conversatorio',
          'Abstract': 'En este conversatorio conoceremos cuáles han sido las experiencias y características que desde el diseño, el proceso y los materiales han sido el origen de la comunicación transversal en sus colecciones, para desarrollar ideas y ser marca diferenciadora a partir de experimentación de materia.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/2',
            'Title': 'Foto Tendencias Conversatorio Marca Pepa Pombo',
            'Description': 'Fotografía del trabajo de conferencia presentado por Pepa Pombo y su hija Mónica Holguín',
            'ImageId': 9
          },
          'WorkId': 5,
          'ShortDescription': 'Conversatorio dirijido por la marca Pepa Pombo y sus directoras, ¡Imperdible! '
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://es-la.facebook.com/PepaPomboColombia/',
          'NetworkName': 'Facebook'
        },
        {
          'Link': 'https://twitter.com/pepapombocom',
          'NetworkName': 'Twitter'
        },
        {
          'Link': 'https://www.instagram.com/pepapombocom/',
          'NetworkName': 'Instagram'
        }
      ]
    },
    {
      'PresenterId': 3,
      'Name': 'Paulo Vaz',
      'Profile': 'Director General de la Asociación Textil y Vestuario de Portugal',
      'Country': 'Portugal',
      'Photo': {
        'ImagePath': 'PresentersImages/3',
        'Title': 'Fotografía Paulo Vaz',
        'Description': 'Fotografía Paulo Vaz',
        'ImageId': 10
      },
      'PreviousWorks': [
        {
          'Title': 'Director General',
          'Abstract': 'Experiencia como director general en la empresa ATP, asociación textil de vestuario en Portugal',
          'Year': '1988',
          'Picture': {
            'ImagePath': 'WorkImages/4',
            'Title': 'Empresa ATP',
            'Description': 'Fotografía en las instalaciones de ATP',
            'ImageId': 11
          },
          'WorkId': 6,
          'ShortDescription': 'Experiencia en ATP'
        },
        {
          'Title': 'Vice Presidente',
          'Abstract': 'Experiencia como Vice presidente de la compañía ASM Associação Selectiva Moda, continúa hasta el momento',
          'Year': '1991',
          'Picture': {
            'ImagePath': 'WorkImages/5',
            'Title': 'Fotografía ASM',
            'Description': 'Fotografía capturada en la fachada de ASM Associação Selectiva Moda',
            'ImageId': 12
          },
          'WorkId': 7,
          'ShortDescription': 'ASM Associação Selectiva Moda'
        },
        {
          'Title': 'Administrador',
          'Abstract': 'Experiencia como Administrador de la Fundação AEP',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'WorkImages/6',
            'Title': 'Fotografía de la AEP',
            'Description': 'Fotografía tomada en las instalaciones de la Fundação AEP',
            'ImageId': 13
          },
          'WorkId': 8,
          'ShortDescription': 'Fundação AEP'
        },
        {
          'Title': 'Administrador',
          'Abstract': 'Administrador en CENIT - Centro de Inteligência Têxtil',
          'Year': '2006',
          'Picture': {
            'ImagePath': 'WorkImages/7',
            'Title': 'Fotografía de CENIT',
            'Description': 'Fotografía tomada en las instalaciones de CENIT - Centro de Inteligência Têxtil',
            'ImageId': 14
          },
          'WorkId': 9,
          'ShortDescription': 'CENIT - Centro de Inteligência Têxtil'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 10,
            'Minutes': 30,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 26,
            'Year': 2016
          },
          'ConferenceId': 3,
          'Title': 'Industria Textil Portuguesa: El Renacimiento del Fenix',
          'Abstract': 'Esta conferencia busca conocer la historia de la decadencia y la recuperación de la industria textil y de vestuario portugués, que ha pasado de ser una industria tradicional a ser un caso de estudio.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/3',
            'Title': 'Foto Conferencia Industria Textil Portuguesa',
            'Description': 'Fotografía del trabajo de conferencia presentado por Paulo Vaz',
            'ImageId': 15
          },
          'WorkId': 10,
          'ShortDescription': 'La industria portuguesa retoma el área textil, ¡averigua aquí como! '
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://www.linkedin.com/in/paulo-vaz-4401ba4',
          'NetworkName': 'Linked In'
        }
      ]
    },
    {
      'PresenterId': 4,
       'Name': 'Federico Gutiérrez',
      'Profile': 'Alcalde de Medellín',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/4',
        'Title': 'Fotografía Federico Gutiérrez',
        'Description': 'Fotografía Federico Gutierrez',
        'ImageId': 16
      },
      'PreviousWorks': [
        {
          'Title': 'Concejal Medellin',
          'Abstract': 'Cargo ocupado desde el año 2003, hasta el 2007 donde subió a vicepresidente para luego postularse como alcalde de Medellín',
          'Year': '2003',
          'Picture': {
            'ImagePath': 'WorkImages/8',
            'Title': 'Alcaldía de Medellín',
            'Description': 'Fotografía alcaldía de Medellín',
            'ImageId': 17
          },
          'WorkId': 11,
          'ShortDescription': 'Cargo anterior ocupado por el Alcalde de Medellín'
        },
        {
          'Title': 'Experiencia en Empresa Privada',
          'Abstract': 'Consultor en HGI y como ingeniero residente en Vifasa ',
          'Year': '2000',
          'Picture': {
            'ImagePath': 'WorkImages/9',
            'Title': 'Fotografía HGI',
            'Description': 'Fotografía en las instalaciones de HGI',
            'ImageId': 18
          },
          'WorkId': 12,
          'ShortDescription': 'Cargos ocupados como Ingeniero Civil'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 14,
            'Minutes': 30,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 26,
            'Year': 2016
          },
          'ConferenceId': 4,
          'Title': 'Ser emprendedor, Experiencia desde la Política',
          'Abstract': '',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/4',
            'Title': 'Foto Conferencia de Federico Gutierrez',
            'Description': 'Fotografía del trabajo de conferencia de Federico Gutierrez, Ser Emprendedor, Experiencia desde la Política',
            'ImageId': 19
          },
          'WorkId': 13,
          'ShortDescription': 'Conferencia política'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://www.facebook.com/FicoGutierrez/',
          'NetworkName': 'Facebook'
        },
        {
          'Link': 'https://twitter.com/ficogutierrez?lang=es',
          'NetworkName': 'Twitter'
        }
      ]
    },
    {
      'PresenterId': 5,
      'Name': 'Mario Hernandez',
      'Profile': 'Presidente de la marca Mario Hernández, con más de 55 tiendas a lo largo de mundo extendiendo tendencias sobre el mundo del cuero Colombiano',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/5',
        'Title': 'Fotografía Mario Hernandez',
        'Description': 'Fotografía Mario Hernandez',
        'ImageId': 20
      },
      'PreviousWorks': [
        {
          'Title': 'Empresario',
          'Abstract': 'Extensión de la empresa Mario Hernandez, multinacional que está prácticamente en los 5 continentes del mundo, a día de hoy una de las empresas más importantes para el mundo de la moda y el estilo en Colombia, prendas que explotan el cuero y las últimas tendencias',
          'Year': '1978',
          'Picture': {
            'ImagePath': 'WorkImages/10',
            'Title': 'Empresa Mario Hernandez',
            'Description': 'Fotografía en una tienda Mario Hernandez',
            'ImageId': 21
          },
          'WorkId': 14,
          'ShortDescription': 'Mario hernandez, ¡empresa de toda la vida! '
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 16,
            'Minutes': 0,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 26,
            'Year': 2016
          },
          'ConferenceId': 5,
          'Title': 'La Vida es una Oportunidad',
          'Abstract': 'El empresario compartirá sus experiencias como emprendedor, y su visión respecto a la inversión en bienestar y desarrollo humano como factor determinante del compromiso entre comunidad y marca.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/5',
            'Title': 'Foto Conferencia de Mario Hernandez',
            'Description': 'Fotografía del trabajo de conferencia de Mario Hernandez, La Vida es una buena oportunidad',
            'ImageId': 22
          },
          'WorkId': 15,
          'ShortDescription': 'Conferencia sobre la historia de una empresa que ahora es un imperio de la moda'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://www.facebook.com/MARIO-HERNANDEZ-61354397854/',
          'NetworkName': 'Facebook'
        },
        {
          'Link': 'https://twitter.com/marioherzam',
          'NetworkName': 'Twitter'
        },
        {
          'Link': 'https://www.instagram.com/mh_colombia/',
          'NetworkName': 'Instagram'
        }
      ]
    },
    {
      'PresenterId': 6,
        'Name': 'Paul Andrés Manrique',
      'Profile': 'Líder de soluciones fotovoltaicas, CELSIA',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/6',
        'Title': 'Fotografía Paul Andrés Manrique',
        'Description': 'Fotografía Paul Andrés Manrique',
        'ImageId': 23
      },
      'PreviousWorks': [
        {
          'Title': 'Docente',
          'Abstract': 'Experiencia como docente en áreas de circuitos, fundamentos de electrónica y electricidad',
          'Year': '2010',
          'Picture': {
            'ImagePath': 'WorkImages/11',
            'Title': 'Universidad del valle',
            'Description': 'Fotografía en la universidad del Valle',
            'ImageId': 24
          },
          'WorkId': 16,
          'ShortDescription': 'Experiencia docente en la Universidad del Valle'
        },
        {
          'Title': 'Investigador y Administrador',
          'Abstract': 'Experiencia en investigación en temas de energías renovables, temas que van desde el uso de procesos industriales hasta el estudio de energía eólica y térmica',
          'Year': '2005',
          'Picture': {
            'ImagePath': 'WorkImages/12',
            'Title': 'Universidad del valle',
            'Description': 'Fotografía de la universidad del valle',
            'ImageId': 25
          },
          'WorkId': 17,
          'ShortDescription': 'Experiencia como investigador, Universidad del valle '
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 17,
            'Minutes': 0,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 26,
            'Year': 2016
          },
          'ConferenceId': 6,
          'Title': 'Las renovables están de moda',
          'Abstract': 'El mundo evoluciona y con él, la manera en que producimos y consumimos la energía que nos permite moverlo. Las energías renovables pasaron de ser una expectativa a convertirse en una opción que está al alcance de la industria y de quienes quieren ser más eficientes y responsables con el medio ambiente.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/6',
            'Title': 'Foto Conferencia de Paul Andrés Manrique',
            'Description': 'Fotografía del trabajo de conferencia de Paul Andrés Manrique, Las renovables están de moda',
            'ImageId': 26
          },
          'WorkId': 18,
          'ShortDescription': 'Conferencia sobre energías renovables'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://co.linkedin.com/in/paulmaco',
          'NetworkName': 'LinkedIn'
        },
        {
          'Link': 'https://www.facebook.com/paul.andres.manrique',
          'NetworkName': 'Facebook'
        }
      ]
    },
    {
      'PresenterId': 7,
      'Name': 'Martha Cálad',
      'Profile': 'Directora del laboratorio de Moda y Económico de Inexmoda',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/7',
        'Title': 'Fotografía Marta Calad',
        'Description': 'Fotografía Calad',
        'ImageId': 27
      },
      'PreviousWorks': [
        {
          'Title': 'La moda según Martha Cálad',
          'Abstract': 'Sus gafas son su sello característico. Las tiene en llamativos diseños que le dan ese aire único a su estilo personal, ese que tanto le admiran sus más cercanos colaboradores. Martha Cálad es una mujer auténtica que respira moda, pero que no es ostentosa ni pretenciosa, porque les huye a los excesos y a la esclavitud de las marcas.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'WorkImages/13',
            'Title': 'Artículo de El Tiempo',
            'Description': 'Es uno de las principales artífices de la edición 27 de Colombiamoda, que arrancó esta semana en Medellín.',
            'ImageId': 28
          },
          'WorkId': 19,
          'ShortDescription': 'La directora del laboratorio de moda de Inexmoda es uno de los pilares de Colombiamoda.'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 9,
            'Minutes': 0,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 7,
          'Title': 'Macrotendencias Primavera – Verano 2017',
          'Abstract': 'Con esta conferencia se dará inicio al 2017 a través de cuatro macrotendencias que nos permitirán entender cómo desde el pensamiento y posteriormente en su comportamiento, las personas se identifican con nuevas opciones que debemos tener claramente identificadas, para diseñar estrategias y procesos creativos coherentes a sus necesidades.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/7',
            'Title': 'Foto conferencia Martha Cábal',
            'Description': 'Fotografía de la conferencia de Martha Cábal',
            'ImageId': 29
          },
          'WorkId': 20,
          'ShortDescription': 'Conferencia sobre nuevas tendencias para el 2017!'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://co.linkedin.com/in/martha-calad-097a9180',
          'NetworkName': 'LinkedIn'
        }
      ]
    },
    {
      'PresenterId': 8,
      'Name': 'Edwing D´Angelo – Daniela Maturana',
      'Profile': 'Diseñador de modas – Concejal de Medellín',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/8',
        'Title': 'Fotografía Edwing D´Angelo y Daniela Maturana',
        'Description': 'Fotografía',
        'ImageId': 30
      },
      'PreviousWorks': [
        {
          'Title': 'Edwing D´Angelo:  Diseñador de Sueños',
          'Abstract': 'Nacido en Buenaventura, este hombre es un creador de moda con sentido social. Con su trabajo busca inspirar a muchos niños que, como le ocurrió a él, no tienen oportunidades para surgir.',
          'Year': '2015',
          'Picture': {
                'ImagePath': 'WorkImages/14',
            'Title': 'Artículo de El Tiempo',
            'Description': 'A pesar de que todo indicaba que sería un abogado, su camino fue la moda.',
            'ImageId': 31
          },
          'WorkId': 21,
          'ShortDescription': 'Autobiografía de Edwing D´Angelo resumida en un artículo'
        },
        {
          'Title': 'Daniela Maturana ¿Quién Soy?',
          'Abstract': 'Desde muy joven estuve interesada en mi Ciudad, en saber qué pasaba en ella, para mi trabajo de grado del colegio realicé un pequeña práctica en el Programa de Paz y Reconciliación de la Alcaldía de Medellín, donde presenté un trabajo final sobre el la desmovilización, la reintegración a civilidad y el post conflicto, trabajo que me ayudó a decidir que quería estudiar ciencias políticas y posteriormente hacer una especialización en comunicación política en la Universidad EAFIT.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'WorkImages/15',
            'Title': 'Fotografía, Daniela Maturana',
            'Description': 'Daniela Maturana, escrito en su web',
            'ImageId': 32
          },
          'WorkId': 22,
          'ShortDescription': 'Descripción de Daniela Maturana de su web oficial'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 10,
            'Minutes': 30,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 8,
          'Title': 'Conversatorio “Origen”',
          'Abstract': 'En este conversatorio Edwing D´Angelo compartirá como ha sido su camino para tener éxito después del resultado de más de 10 años de aprendizajes y experiencias en la industria de la moda americana. Su aporte desde el diseño de modas a la inclusión social, política y económica de las poblaciones étnicas en Colombia y el mundo, así como la consolidación de negocios sostenibles a través de la apuesta Origen.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/8',
            'Title': 'Foto conferencia Origen',
            'Description': 'Fotografía de la conferencia Origen',
            'ImageId': 32
          },
          'WorkId': 23,
          'ShortDescription': 'Conferencia sobre una experiencia de 10 años en el mundo de la moda NorteAmericana'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://www.instagram.com/edwingdangelo/',
          'NetworkName': 'Instagram'
        },
        {
          'Link': 'https://www.facebook.com/edwingdangelo',
          'NetworkName': 'Facebook'
        },
        {
          'Link': 'https://twitter.com/dany_matu',
          'NetworkName': 'Twitter'
        }
      ]
    },
    {
      'PresenterId': 9,
      'Name': 'Jeihhco',
      'Profile': 'Artista hip hop de C15 y socio fundador de la Casa Kolacho',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/9',
        'Title': 'Fotografía Jeihhco',
        'Description': 'Fotografía',
        'ImageId': 33
      },
      'PreviousWorks': [
        {
          'Title': 'Los de camiseta también construimos país',
          'Abstract': 'Jeison Castaño “Jeihhco”, Hip Hopper y líder juvenil, lleva 13 de sus 29 años involucrado en la gestión de proyectos culturales y sociales. Y casi 20 años en la música. Dirige la Escuela de Hip Hop de la “Casa Kolacho”, un centro cultural ubicado en la Comuna 13 de Medellín.',
          'Year': '2015',
          'Picture': {
            'ImagePath': 'WorkImages/16',
            'Title': 'Artículo de la Silla Vacía',
            'Description': 'Colectivo C-15',
            'ImageId': 34
          },
          'WorkId': 24,
          'ShortDescription': 'Descripción y biografía de Jiehhco en La Silla Vacía '
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 11,
            'Minutes': 40,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 9,
          'Title': 'Hip Hop como estilo de vida',
          'Abstract': 'Medellín es un laboratorio de ciudad, donde experimentamos a diario, porque estamos cansados de sufrir, porque estamos cansados de vivir lo que hemos vivido. Porque creemos que es posible tener un mundo mejor y que somos capaces de hacerlo.” Este es el mensaje que siempre trasmite Jeihhco, quien con su conferencia llevará a la gente a sentir pasión, a reflexionar y finalmente transformar su alrededor con acciones de impacto.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/9',
            'Title': 'Foto conferencia Hip Hop, Estilo de vida',
            'Description': 'Fotografía de la conferencia Hip Hop, Estilo de vida',
            'ImageId': 35
          },
          'WorkId': 25,
          'ShortDescription': 'Conferencia sobre el hip-hop como un reflejo de la ciudad'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://www.instagram.com/edwingdangelo/',
          'NetworkName': 'Instagram'
        },
        {
          'Link': 'https://twitter.com/jeihhco?lang=es',
          'NetworkName': 'Twitter'
        }
      ]
    },
    {
      'PresenterId': 10,
      'Name': 'Natalia Zambrano',
      'Profile': 'Directora de Categoría en Compañía de Galletas Noel S.A.S.',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/10',
        'Title': 'Fotografía Natalia Zambrano',
        'Description': 'Fotografía',
        'ImageId': 36
      },
      'PreviousWorks': [
        {
          'Title': 'Jefe de Marca en Noel',
          'Abstract': 'Cargo desempeñado desde el año 2003, Jefa de marca para galletas Noel S.A.S',
          'Year': '2003',
          'Picture': {
            'ImagePath': 'WorkImages/17',
            'Title': 'Noel S.A.S',
            'Description': 'Fotografía en las instalaciones de Noel S.A.S',
            'ImageId': 37
          },
          'WorkId': 26,
          'ShortDescription': 'Experiencia en Noel S.A.S '
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 14,
            'Minutes': 0,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 10,
          'Title': '100 años creando momentos para compartir',
          'Abstract': 'Un recuento por la historia de esta compañía; conoceremos cómo Noel a través de estos 100 años se ha conectado emocionalmente con el consumidor.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/10',
            'Title': 'Foto conferencia de Natalia Zambrano',
            'Description': 'Fotografía de la conferencia 100 Años, creando momentos para compartir',
            'ImageId': 38
          },
          'WorkId': 27,
          'ShortDescription': 'La larga historia de Noel y sus productos!'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://co.linkedin.com/in/natalia-zambrano-51701210',
          'NetworkName': 'LinkedIn'
        },
        {
          'Link': 'https://es-la.facebook.com/natalia.zambrano.927',
          'NetworkName': 'Facebook'
        }
      ]
    },
    {
      'PresenterId': 11,
      'Name': 'Socorro Jaramillo',
      'Profile': 'CEO Havas Worldwide',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/11',
        'Title': 'Fotografía Socorro Jaramillo',
        'Description': 'Fotografía',
        'ImageId': 39
      },
      'PreviousWorks': [
        {
          'Title': 'Reconocimientos importantes de su carrera',
          'Abstract': 'reconocimiento “Publicitario Latinoamericano” en el festival mundial de Publicidad de Gramado, Brasil, en el año 2007 y con el premio “30 años de trayectoria” otorgado por la Asociación Nacional de Anunciantes, Anda, en el año 2009, entre otros eventos de talla internacional.',
          'Year': '2007',
          'Picture': {
            'ImagePath': 'WorkImages/18',
            'Title': 'Socorro Jaramillo',
            'Description': 'Fotografía de Socorro Jaramillo',
            'ImageId': 40
          },
          'WorkId': 28,
          'ShortDescription': 'Logros importantes de una reconocida publicista en Colombia'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 15,
            'Minutes': 0,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 11,
          'Title': 'El espíritu de las marcas exitosas',
          'Abstract': 'Pensar, sentir y conectar es el gran reto que tiene la publicidad para hacer relevantes las marcas. En esta conferencia conoceremos estrategias exitosas y el secreto que hay detrás de ellas para lograr ir más allá del top of mind.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/11',
            'Title': 'Foto conferencia de Socorro Jaramillo',
            'Description': 'Fotografía de la conferencia El Espiritu de las Marcas Exitosas',
            'ImageId': 41
          },
          'WorkId': 29,
          'ShortDescription': '¡Estrategias de publicidad imperdibles para llevar una marca de lo desconocido al éxito!'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://twitter.com/socojaramillov',
          'NetworkName': 'Twitter'
        }
      ]
    },
    {
      'PresenterId': 12,
      'Name': 'Nicolás Burgert',
      'Profile': 'Director Comercial, negociador internacional y productor de cine. Experto en relojería.',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/12',
        'Title': 'Fotografía Nicolás Burgert',
        'Description': 'Fotografía',
        'ImageId': 42
      },
      'PreviousWorks': [
        {
          'Title': 'Ejecutivo de ventas',
          'Abstract': 'Experiencia como ejecutivo de ventas para Relojes Mistura, desde 2013 hasta la fecha',
          'Year': '2013',
          'Picture': {
            'ImagePath': 'WorkImages/19',
            'Title': 'Nicolas Burgert',
            'Description': 'Fotografía de Nicolas Burgert',
            'ImageId': 43
          },
          'WorkId': 30,
          'ShortDescription': 'Experiencia como ejecutivo de ventas'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 16,
            'Minutes': 0,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 12,
          'Title': 'La mezcla entre la precisión de la relojería y el azar de la naturaleza',
          'Abstract': 'Esta conferencia se enfocará en la historia de la marca, en cómo estos emprendedores unieron dos cosas para crear un producto: madera y relojería. “Mistura significa mezcla, y es el nombre porque consideramos que cualquier equilibrio nace de mezclar conocimientos, experiencias, profesiones, y materiales.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/12',
            'Title': 'Foto conferencia de Nicolás Burgert',
            'Description': 'Fotografía de la conferencia de Nicolás Burgert',
            'ImageId': 44
          },
          'WorkId': 31,
          'ShortDescription': '¡Estrategias de publicidad imperdibles para llevar una marca de lo desconocido al éxito!'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://co.linkedin.com/in/nicolas-burgert-0b559b29',
          'NetworkName': 'LinkedIn'
        }
      ]
    },
    {
      'PresenterId': 13,
      'Name': 'Juan Carlos Molina Villegas',
      'Profile': 'Director de La Tienda Creativa',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/13',
        'Title': 'Fotografía Juan Carlos Molina Villegas',
        'Description': 'Fotografía',
        'ImageId': 45
      },
      'PreviousWorks': [
        {
          'Title': 'Tienda creativa y de integración',
          'Abstract': 'Nosotros tenemos una cara pública que es La Tienda Creativa y tenemos otra corporativa que es la que se denomina Integración Publicidad, explica Molina antes de hablar de los servicios que ofrece la agencia: producción creativa e ideas para comunicar productos y servicios, así como todas las actividades relacionadas con las campañas como producción de radio, televisión, prensa, VTR, revistas, vallas y material de punto de venta.',
          'Year': '1984',
          'Picture': {
            'ImagePath': 'WorkImages/20',
            'Title': 'Tienda creativa y de integración',
            'Description': 'Fotografía de la empresa',
            'ImageId': 46
          },
          'WorkId': 32,
          'ShortDescription': '¡32 años en la industria de la publicidad!'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 17,
            'Minutes': 0,
            'Seconds': 0
          },
          'Date': {
            'Month': 7,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 13,
          'Title': 'SimpleMente: el poder de una buena idea',
          'Abstract': 'Hoy en día la manera de vender es saber contar una buena historia. Durante más de 30 años esta ha sido la tarea de la valla de La Tienda Creativa, que con cada nueva frase consigue tocar el corazón y la memoria de las personas. Actualmente el reto es escuchar a la gente, adaptarse a los cambios y volver a lo simple. Las ideas más poderosas se consiguen prestando atención.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/13',
            'Title': 'Foto conferencia de Juan Carlos Molina Villegas',
            'Description': 'Foto conferencia de Juan Carlos Molina Villegas',
            'ImageId': 47
          },
          'WorkId': 33,
          'ShortDescription': '¡Cuenta una historia, vende con ella! '
        }
      ],
      'SocialNetworks': [
      ]
    },
    {
      'PresenterId': 14,
      'Name': 'Camilo Herrera',
      'Profile': 'Presidente de Raddar',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/14',
        'Title': 'Fotografía Camilo Herrera',
        'Description': 'Fotografía',
        'ImageId': 48
      },
      'PreviousWorks': [
        {
          'Title': 'Presidente Raddar',
          'Abstract': 'Experiencia como presidente de la empresa RADDAR desde el año 2006, manteniendo la filosofía y compromiso de la empresa con los comportamientos del consumidor',
          'Year': '2006',
          'Picture': {
            'ImagePath': 'WorkImages/21',
            'Title': 'Empresa Raddar',
            'Description': 'Fotografía de la empresa',
            'ImageId': 49
          },
          'WorkId': 34,
          'ShortDescription': '10 años conservando y analizando las políticas de consumo'
        },
        {
          'Title': 'Centro de Estudios Culturales',
          'Abstract': 'Experiencia como presidente del centro de estudios Culturales hasta el 2004',
          'Year': '1999',
          'Picture': {
            'ImagePath': 'WorkImages/22',
            'Title': 'Centro de estudios culturales',
            'Description': 'Fotografía de la empresa',
            'ImageId': 50
          },
          'WorkId': 35,
          'ShortDescription': '¡5 años de análisis cultural!'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 9,
            'Minutes': 0,
            'Seconds': 0
          },
          'Date': {
            'Month': 8,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 14,
          'Title': 'Consumer voice: ¿qué está cambiando al consumidor colombiano y cómo lo está haciendo?',
          'Abstract': '',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/14',
            'Title': 'Foto conferencia de Camilo Herrera',
            'Description': 'Foto conferencia de Camilo Herrera',
            'ImageId': 51
          },
          'WorkId': 36,
          'ShortDescription': ''
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://co.linkedin.com/in/camilo-herrera-b5874125',
          'NetworkName': 'LinkedIn'
        },
        {
          'Link': 'https://www.facebook.com/camilo.h.mora?fref=nf',
          'NetworkName': 'Facebook'
        },
        {
          'Link': 'https://twitter.com/consumiendo?lang=es',
          'NetworkName': 'Twitter'
        }
      ]
    },
    {
      'PresenterId': 15,
      'Name': 'Marielle Bobo',
      'Profile': 'Directora de Moda y Belleza de la revista Ebony *Conferencia con traducción simultánea',
      'Country': 'Estados Unidos',
      'Photo': {
        'ImagePath': 'PresentersImages/15',
        'Title': 'Fotografía Marielle Bobo',
        'Description': 'Fotografía',
        'ImageId': 52
      },
      'PreviousWorks': [
        {
          'Title': 'Directora de Moda y Belleza de la revista Ebony',
          'Abstract': 'Experiencia en dirección de moda y belleza en la revista Ebony, para todas sus secciones, estilo, moda y belleza.',
          'Year': '2011',
          'Picture': {
            'ImagePath': 'WorkImages/23',
            'Title': 'Revista Ebony',
            'Description': 'Fotografía de la revista',
            'ImageId': 53
          },
          'WorkId': 37,
          'ShortDescription': '¡Dirección de moda y belleza!'
        },
        {
          'Title': 'Editora de revista Senior',
          'Abstract': 'Experiencia en edición de revistas de moda como Escence, Ok!, Vanity Fair y Allure Magazine entre otras',
          'Year': '2005',
          'Picture': {
            'ImagePath': 'WorkImages/24',
            'Title': 'Revista Vanity Fair',
            'Description': 'Fotografía de la revista',
            'ImageId': 54
          },
          'WorkId': 38,
          'ShortDescription': '¡Editando belleza!'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 10,
            'Minutes': 30,
            'Seconds': 0
          },
          'Date': {
            'Month': 8,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 15,
          'Title': 'Consumer voice: ¿qué está cambiando al consumidor colombiano y cómo lo está haciendo?',
          'Abstract': 'Dada su vasta experiencia en la industria de la moda, Marielle vinculará su conferencia con nuestro programa ” Origen” y hablará sobre el segmento del mercado étnico y cómo podemos utilizar nuestras raíces como una ventaja competitiva en el mercado.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/15',
            'Title': 'Foto conferencia de Marielle Bobo',
            'Description': 'Foto conferencia de Marielle Bobo',
            'ImageId': 55
          },
          'WorkId': 39,
          'ShortDescription': 'Crea tendencia desde lo étnico ¿Te atreves?'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://www.linkedin.com/in/marielle-bobo-3672a96',
          'NetworkName': 'LinkedIn'
        },
        {
          'Link': 'https://www.facebook.com/mariellecbobo',
          'NetworkName': 'Facebook'
        },
        {
          'Link': 'https://twitter.com/maricbobo',
          'NetworkName': 'Twitter'
        }
      ]
    },
    {
      'PresenterId': 16,
      'Name': 'Miguel Piedrahita',
      'Profile': 'CEO Maaji Underwear',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/16',
        'Title': 'Fotografía Miguel Piedrahita',
        'Description': 'Fotografía',
        'ImageId': 56
      },
      'PreviousWorks': [
        {
          'Title': 'Banca de inversión Bancolombia',
          'Abstract': 'Experiencia que escala desde analista de investigación hasta líder para la estrategia de transformación digital',
          'Year': '2006',
          'Picture': {
            'ImagePath': 'WorkImages/25',
            'Title': 'Bancolombia',
            'Description': 'Fotografía de la empresa',
            'ImageId': 57
          },
          'WorkId': 40,
          'ShortDescription': 'Rumbo hacia convertirse en CEO'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 11,
            'Minutes': 30,
            'Seconds': 0
          },
          'Date': {
            'Month': 8,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 16,
          'Title': 'Caso Maaji',
          'Abstract': 'Bajo el tema del día “Conectar” Miguel contará como fue generar la conexión de un hombre de la banca que paso a liderar la estrategia de crecimiento de una marca de moda con tanto futuro como Maaji.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/16',
            'Title': 'Foto conferencia de Miguel Piedrahita',
            'Description': 'Foto conferencia Caso Maaji',
            'ImageId': 58
          },
          'WorkId': 41,
          'ShortDescription': '¡Conectate con la estrategia de crecimiento de una empresa!'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://co.linkedin.com/in/miguel-piedrahita-33634727',
          'NetworkName': 'LinkedIn'
        }
      ]
    },
    {
      'PresenterId': 17,
      'Name': 'Marisol Camacho',
      'Profile': 'Gerente de conexión y movilización de Bancoldex',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/17',
        'Title': 'Fotografía Marisol Camacho',
        'Description': 'Fotografía',
        'ImageId': 59
      },
      'PreviousWorks': [
        {
          'Title': 'Dirección de...',
          'Abstract': 'Preparada como directora, ya sea de comunicaciones en la vicepresidencia de colombia o de cultura en iNNpulsa o de relaciones corporativas en Bacoldex',
          'Year': '2008',
          'Picture': {
            'ImagePath': 'WorkImages/26',
            'Title': 'Bancoldex',
            'Description': 'Fotografía de la empresa',
            'ImageId': 60
          },
          'WorkId': 42,
          'ShortDescription': 'Directora versatil de relaciones'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 14,
            'Minutes': 0,
            'Seconds': 0
          },
          'Date': {
            'Month': 8,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 17,
          'Title': 'Una mentalidad de moda',
          'Abstract': '',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/17',
            'Title': 'Foto conferencia de Marisol Camacho',
            'Description': 'Foto conferencia Marisol Camacho',
            'ImageId': 61
          },
          'WorkId': 43,
          'ShortDescription': ''
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://co.linkedin.com/in/marisol-camacho-13789610',
          'NetworkName': 'LinkedIn'
        },
        {
          'Link': 'https://twitter.com/msolcamacho',
          'NetworkName': 'Twitter'
        }
      ]
    },
    {
      'PresenterId': 18,
      'Name': 'Lucrecia Piedrahíta Orrego',
      'Profile': 'Curadora de Arte, Museóloga, Especialista en Política y Periodismo, Estudiante de Arquitectura UPB ',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/18',
        'Title': 'Fotografía Lucrecia Piedrahita',
        'Description': 'Fotografía',
        'ImageId': 62
      },
      'PreviousWorks': [
        {
          'Title': 'Quien soy!',
          'Abstract': 'Lucrecia Piedrahita. Es Museóloga de la Universidad Internacional del Arte, Florencia, Italia. Curadora de Arte -becaria LIPAC – Universidad de Buenos Aires, Argentina. Becaria de Curaduría Residencias Sweet Home – Ayuntamiento de Madrid y Matadero Madrid 2013. Especialista en Periodismo Urbano de la UPB. Especialista en Estudios Políticos en la Universidad Eafit. Actualmente candidata a Magister en Teoría Crítica del 17 Instituto de Estudios Críticos de México, D.F. Estudiante de Arquitectura, Facultad de Arquitectura UPB.',
          'Year': 1993,
          'Picture': {
            'ImagePath': 'WorkImages/27',
            'Title': 'Universidad internacional del arte',
            'Description': 'Fotografía de la universidad',
            'ImageId': 63
          },
          'WorkId': 44,
          'ShortDescription': 'Experiencia de la academía a su profesión'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 14,
            'Minutes': 0,
            'Seconds': 0
          },
          'Date': {
            'Month': 8,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 18,
          'Title': 'La moda y el arte, una curaduría agitada',
          'Abstract': '',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/18',
            'Title': 'Foto conferencia de Lucrecia Piedrahita',
            'Description': 'Foto conferencia Lucrecia Piedrahita',
            'ImageId': 64
          },
          'WorkId': 45,
          'ShortDescription': ''
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://www.facebook.com/Estudio-Curadur%C3%ADa-811734922174931/',
          'NetworkName': 'Facebook'
        },
        {
          'Link': 'https://twitter.com/LucrePiedrahita',
          'NetworkName': 'Twitter'
        }
      ]
    },
    {
      'PresenterId': 19,
      'Name': 'Daniel Moreno',
      'Profile': 'Director de Alianzas y eventos Hatsu.',
      'Country': 'Colombia',
      'Photo': {
        'ImagePath': 'PresentersImages/19',
        'Title': 'Fotografía Daniel Moreno',
        'Description': 'Fotografía',
        'ImageId': 65
      },
      'PreviousWorks': [
        {
          'Title': 'Director de mercadeo',
          'Abstract': 'Director de mercadeo en la empresa HATSU, desde el año 2012',
          'Year': '2012',
          'Picture': {
            'ImagePath': 'WorkImages/28',
            'Title': 'Empresa HATSU',
            'Description': 'Fotografía de la Empresa',
            'ImageId': 66
          },
          'WorkId': 46,
          'ShortDescription': 'Experiencia como director de mercadeo'
        },
        {
          'Title': 'Director de proyectos',
          'Abstract': 'Director de proyectos en Contreebute del año 2010 al 2012',
          'Year': '2010',
          'Picture': {
            'ImagePath': 'WorkImages/29',
            'Title': 'Empresa Contreebute',
            'Description': 'Fotografía de la Empresa',
            'ImageId': 67
          },
          'WorkId': 47,
          'ShortDescription': 'Experiencia como director de proyecto'
        },
        {
          'Title': 'Director de operaciones',
          'Abstract': 'Director de proyectos en Contreebute del año 2008 al 2010',
          'Year': '2008',
          'Picture': {
            'ImagePath': 'WorkImages/30',
            'Title': 'Organización Swiss Andina',
            'Description': 'Fotografía de la Empresa',
            'ImageId': 68
          },
          'WorkId': 48,
          'ShortDescription': 'Experiencia como director de operaciones'
        }
      ],
      'Conferences': [
        {
          'ConferencePlace': {
            'Address': 'Calle 41 # 55 - 80',
            'Capacity': 10000,
            'City': 'Medellin',
            'Country': 'Colombia',
            'Location': {
              'Longitude': -75.57614,
              'Latitude': 6.24347
            },
            'Name': 'Pabellon Plaza Mayor Medellin',
            'Neighborhood': 'Plaza',
            'Picture': {
              'Description': 'Foto tomada en el pabellón de la plaza mayor de Medellín, Aquí se hará el evento de Colombia moda ',
              'ImageId': 1,
              'ImagePath': 'PlaceImages/1',
              'Title': 'Foto Plaza Mayor Medellin'
            },
            'PlaceId': 1
          },
          'Hour': {
            'Hours': 14,
            'Minutes': 0,
            'Seconds': 0
          },
          'Date': {
            'Month': 8,
            'Day': 27,
            'Year': 2016
          },
          'ConferenceId': 19,
          'Title': 'Conexión con coherencia',
          'Abstract': 'El posicionamiento de una marca se logra a partir de la coherencia en la aplicación de sus valores. HATSU ha logrado crear una relación con sus diferentes grupos de interés a partir de una estrategia inspirada por la consciencia y la evolución de las personas.',
          'Year': '2016',
          'Picture': {
            'ImagePath': 'ConferenceImages/19',
            'Title': 'Foto conferencia de Daniel Moreno',
            'Description': 'Foto conferencia Daniel Moreno',
            'ImageId': 69
          },
          'WorkId': 49,
          'ShortDescription': '¡Aprende a entender la coherencia entre el valor y la marca!'
        }
      ],
      'SocialNetworks': [
        {
          'Link': 'https://co.linkedin.com/in/daniel-moreno-b9a89bab',
          'NetworkName': 'LinkedIn'
        },
        {
          'Link': 'https://twitter.com/morenacion',
          'NetworkName': 'Twitter'
        }
      ]
    }
  ],
  'FrequentQuestions': [
    {
      'Question': '¿Dónde es el Pabellón del Conocimiento Inexmoda – UPB?',
      'Answer': 'En esta edición de Colombiamoda, el Pabellón desarrollará su programación en el Pabellón Medellín de Plaza Mayor. Anteriormente, esta agenda académica de la Feria se llevaba a cabo en el Teatro Metropolitano.',
      'QuestionId': 1
    },
    {
      'Question': '¿A cuántas conferencias me puedo inscribir a través de la página?',
      'Answer': 'Cada persona tiene derecho únicamente a inscribirse a nueve (9) conferencias durante los tres (3) días, sin embargo si en el momento del inicio de la conferencia se presentan espacios libres dentro de los salones, miembros del staff anunciarán esta disponibilidad en los puntos de ingreso del Pabellón.',
      'QuestionId': 2
    },
    {
      'Question': 'Si no logro inscribirme con anterioridad, ¿puedo inscribirme el mismo día?',
      'Answer': 'Sí, pero todo dependerá de la disponibilidad de cupos con los que cuente cada conferencia.',
      'QuestionId': 3
    },
    {
      'Question': '¿Por dónde puedo ingresar si no tengo escarapela?',
      'Answer': 'Debes ingresar por la entrada ubicada en la Av. Regional; habrá una marcación del lugar que te indicará el ingreso al Pabellón Medellín de Plaza Mayor, es decir al frente al Teatro Metropolitano.',
      'QuestionId': 4
    },
    {
      'Question': 'Si tengo escarapela, ¿debo inscribirme a las conferencias y talleres?',
      'Answer': 'Sí, todas las personas que quieran asistir al Pabellón del Conocimiento Inexmoda-UPB deben inscribirse a través de la página web www.colombiamoda.com para participar en sus conferencias y talleres.',
      'QuestionId': 5
    },
    {
      'Question': 'Si tengo escarapela, ¿debo salir del recinto ferial para ingresa al Pabellón del Conocimiento?',
      'Answer': 'No es necesario. Habrá un punto de registro conjunto al Foro de Tendencias (Pabellón Verde), por donde se autorizará el ingreso a las personas que cuenten con escarapela.',
      'QuestionId': 6
    }
  ],
  'ImageGallery': [
    {
      'ImagePath': 'ImageGallery/1',
      'Title': '',
      'Description': '',
      'ImageId': 100
    },
    {
      'ImagePath': 'ImageGallery/2',
      'Title': '',
      'Description': '',
      'ImageId': 101
    },
    {
      'ImagePath': 'ImageGallery/3',
      'Title': '',
      'Description': '',
      'ImageId': 102
    },
    {
      'ImagePath': 'ImageGallery/4',
      'Title': '',
      'Description': '',
      'ImageId': 103
    },
    {
      'ImagePath': 'ImageGallery/5',
      'Title': '',
      'Description': '',
      'ImageId': 104
    },
    {
      'ImagePath': 'ImageGallery/6',
      'Title': '',
      'Description': '',
      'ImageId': 105
    },
    {
      'ImagePath': 'ImageGallery/7',
      'Title': '',
      'Description': '',
      'ImageId': 106
    },
    {
      'ImagePath': 'ImageGallery/8',
      'Title': '',
      'Description': '',
      'ImageId': 107
    },
    {
      'ImagePath': 'ImageGallery/9',
      'Title': '',
      'Description': '',
      'ImageId': 108
    },
    {
      'ImagePath': 'ImageGallery/10',
      'Title': '',
      'Description': '',
      'ImageId': 109
    }
  ],
  'EventId' :  1
}";
        }
    }
}
