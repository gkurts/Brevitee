RMDIR /S /Q C:\src\Brevitee\Brevitee\Products\bam\app
RMDIR /S /Q C:\src\Brevitee\Brevitee\Products\bam\content
MD C:\src\Brevitee\Brevitee\Products\bam\app
MD C:\src\Brevitee\Brevitee\Products\bam\content
xcopy c:\BreviteeContentRoot\apps\localhost C:\src\Brevitee\Brevitee\Products\bam\app\ /E
xcopy c:\BreviteeContentRoot\apps\localhost C:\src\Brevitee\Brevitee\Products\bam\content\apps\localhost\ /E
copy c:\BreviteeContentRoot\apps\include.js C:\src\Brevitee\Brevitee\Products\bam\content\apps\include.js
xcopy c:\BreviteeContentRoot\common C:\src\Brevitee\Brevitee\Products\bam\content\common\ /E
xcopy c:\BreviteeContentRoot\serverWorkspace C:\src\Brevitee\Brevitee\Products\bam\content\serverWorkspace\ /E