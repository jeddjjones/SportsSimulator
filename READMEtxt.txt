
select * from Player


insert into player 
select 1, 'NBA', [ID], [Name_ID], [TeamAbbrev], '', [Position], [Salary], 0.00, 0.00, 0.00, 0
from IMPORT_DK_NBA_012923

update player set Opponent='IND' where team='MEM'
update player set Opponent='MEM' where team='IND'
update player set Opponent='LAC' where team='CLE'
update player set Opponent='CLE' where team='LAC'
update player set Opponent='NOP' where team='MIL'
update player set Opponent='MIL' where team='NOP'

update player set teamcss = 'background-color: #E03A3E; color: #FDB927;' where team='ATL'
update player set teamcss = 'background-color: #007A33; color: #BA9653;' where team='BOS'
update player set teamcss = 'background-color: #000000; color: #FFFFFF;' where team='BKN'
update player set teamcss = 'background-color: #1D1160; color: #00788C;' where team='CHA'
update player set teamcss = 'background-color: #CE1141; color: #000000;' where team='CHI'
update player set teamcss = 'background-color: #860038; color: #FDBB30;' where team='CLE'
update player set teamcss = 'background-color: #002B5E; color: #B8C4CA;' where team='DAL'
update player set teamcss = 'background-color: #FEC524; color: #0E2240;' where team='DEN'
update player set teamcss = 'background-color: #1D42BA; color: #C8102E;' where team='DET'
update player set teamcss = 'background-color: #FFC72C; color: #1D428A;' where team='GSW'
update player set teamcss = 'background-color: #CE1141; color: #FFFFFF;' where team='HOU'
update player set teamcss = 'background-color: #002D62; color: #FDBB30;' where team='IND'
update player set teamcss = 'background-color: #C8102E; color: #BEC0C2;' where team='LAC'
update player set teamcss = 'background-color: #FDB927; color: #552583;' where team='LAL'
update player set teamcss = 'background-color: #5D76A9; color: #F5B112;' where team='MEM'
update player set teamcss = 'background-color: #98002E; color: #000000;' where team='MIA'
update player set teamcss = 'background-color: #00471B; color: #EEE1C6;' where team='MIL'
update player set teamcss = 'background-color: #236192; color: #78BE20;' where team='MIN'
update player set teamcss = 'background-color: #0C2340; color: #85714D;' where team='NOP'
update player set teamcss = 'background-color: #006BB6; color: #F58426;' where team='NYK'
update player set teamcss = 'background-color: #007AC1; color: #EF3B24;' where team='OKC'
update player set teamcss = 'background-color: #0077C0; color: #C4CED4;' where team='ORL'
update player set teamcss = 'background-color: #C4CED4; color: #ED174C;' where team='PHI'
update player set teamcss = 'background-color: #1D1160; color: #E56020;' where team='PHX'
update player set teamcss = 'background-color: #E03A3E; color: #000000;' where team='POR'
update player set teamcss = 'background-color: #5A2D81; color: #63727A;' where team='SAC'
update player set teamcss = 'background-color: #C4CED4; color: #000000;' where team='SAS'
update player set teamcss = 'background-color: #CE1141; color: #000000;' where team='TOR'
update player set teamcss = 'background-color: #002B5C; color: #F9A01B;' where team='UTA'
update player set teamcss = 'background-color: #002B5C; color: #E31837;' where team='WAS'


