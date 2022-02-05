library CoParticipacao;

uses
  System.SysUtils,
  System.Classes;

{$R *.res}

function Calcular(Valor: Double) : Double   ; export ; stdcall;

Begin
  if (Valor < 1000) then
  begin
     Result := Valor * 0.10;
  end
  else if (Valor > 1000) AND (VALOR <= 2000) then
  Begin
    Result := Valor * 0.20;
  End
  else if (Valor > 2000 ) AND (VALOR <= 3000) then
  begin
    Result := Valor * 0.30;
  end
  else if (Valor > 3000 ) then
  begin
    Result :=  Valor * 0.40;
  end;


END;



exports
Calcular;

begin
end.
