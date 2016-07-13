SELECT Banner.Codigo,Banner.Nombre,Banner.Fuente_Codigo,RangoHorarios.HoraInicio,RangoHorarios.HoraFin,
	   Fuente.Valor, RangoFechas.FechaInicio, RangoFechas.FechaFin
		FROM Banner, Fuente, FuenteRSS, RangoFecheable, RangoFechas, RangoHorarios
		WHERE Banner.Codigo = RangoFecheable.Codigo and RangoFecheable.Codigo = RangoFechas.Principal_Codigo and
			  RangoHorarios.RangoFecha_Codigo = RangoFechas.Codigo and Fuente.Codigo = FuenteRSS.Codigo and 
			  Banner.Fuente_Codigo = Fuente.Codigo;