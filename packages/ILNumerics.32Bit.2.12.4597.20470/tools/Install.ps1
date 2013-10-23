param($installPath, $toolsPath, $package, $project)

#$project = Get-Project

# make all files in Dependency folder 'CopyIfNewer' to Output Dir
$project.ProjectItems | Where { $_.Name -like '*.dll' } | 
    foreach {
        Write-Host processing dependency: $_.Name    
        $_.Properties.Item("CopyToOutputDirectory").Value = 2
        $_.Properties.Item("BuildAction").Value = 0 
    }
