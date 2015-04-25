call C:\src\Brevitee\Brevitee\Products\bam\copy_content_root_files.cmd
del C:\src\Brevitee\Brevitee\Brevitee.Server\app.base
del C:\src\Brevitee\Brevitee\Brevitee.Server\content.root
C:\src\Brevitee\Brevitee\Brevitee.Server\7zip\7za a -tzip C:\src\Brevitee\Brevitee\Brevitee.Server\app.base C:\src\Brevitee\Brevitee\Products\bam\app\*
C:\src\Brevitee\Brevitee\Brevitee.Server\7zip\7za a -tzip C:\src\Brevitee\Brevitee\Brevitee.Server\content.root C:\src\Brevitee\Brevitee\Products\bam\content\*